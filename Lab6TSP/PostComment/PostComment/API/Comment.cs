using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostComment
{
    public partial class Comment
    {
        public bool AddComment()
        {
            using (ModelPostCommentContainer ctx = new ModelPostCommentContainer())
            {
                bool bResult = false;
                if (this == null || this.PostPostId == 0)
                    return bResult;
                if (this.Id == 0)
                {
                    ctx.Entry<Comment>(this).State = EntityState.Added;
                    Post p = ctx.Posts.Find(this.PostPostId);
                    ctx.Entry<Post>(p).State = EntityState.Unchanged;
                    ctx.SaveChanges();
                    bResult = true;
                }
                return bResult;
            }
        }

        public Comment UpdateComment(Comment newComment)
        {
            using (ModelPostCommentContainer ctx = new ModelPostCommentContainer())
            {
                Comment oldComment = ctx.Comments.Find(newComment.Id);

                // Deoarece parametrul este un Comment ar trebui verificata fiecare
                // proprietate din newComment daca are valoare atribuita si
                // daca valoarea este diferita de cea din bd.
                // Acest lucru il fac numai la modificarea asocierii.

                if (newComment.Text != null)
                    oldComment.Text = newComment.Text;

                if ((oldComment.PostPostId != newComment.PostPostId) && (newComment.PostPostId != 0))
                    oldComment.PostPostId = newComment.PostPostId;

                ctx.SaveChanges();

                return oldComment;
            }
        }

        public Comment UpdateOldCommentWithNewOne(Comment oldComment, Comment newComment)
        {
            using (ModelPostCommentContainer ctx = new ModelPostCommentContainer())
            {
                if (newComment.Text != null)
                    oldComment.Text = newComment.Text;

                if ((oldComment.PostPostId != newComment.PostPostId) && (newComment.PostPostId != 0))
                    oldComment.PostPostId = newComment.PostPostId;

                ctx.SaveChanges();

                return oldComment;
            }
        }

        public bool AddCommentById(int postId, Comment comment)
        {
            using (ModelPostCommentContainer ctx = new ModelPostCommentContainer())
            {
                if (comment == null || postId == 0 || comment.Id != 0)
                    return false;

                comment.PostPostId = postId;

                ctx.Entry(comment).State = EntityState.Added;

                Post p = ctx.Posts.Find(postId);
                ctx.Entry(p).State = EntityState.Unchanged;
                ctx.SaveChanges();

                return true;
            }
        }

        public Comment GetCommentById(int id)
        {
            using (ModelPostCommentContainer ctx = new ModelPostCommentContainer())
            {
                var items = from c in ctx.Comments where (c.Id == id) select c;
                return items.Include(p => p.Post).SingleOrDefault();
            }
        }

        public int DeleteComment(int id)
        {
            using (ModelPostCommentContainer ctx = new ModelPostCommentContainer())
            {
                return ctx.Database.ExecuteSqlCommand("Delete From Comment where postid = @p0", id);
            }
        }
    }
}
