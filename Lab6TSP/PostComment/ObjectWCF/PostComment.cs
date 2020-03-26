using PostComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectWCF
{
    public class PostComment : IPostComment
    {
        bool InterfaceComment.AddComment(Comment comment)
        {
            return comment.AddComment();
        }

        bool InterfacePost.AddPost(Post post)
        {
            return post.AddPost();
        }

        int InterfacePost.DeletePost(int id)
        {
            Post post = new Post();
            return post.DeletePost(id);
        }

        Comment InterfaceComment.GetCommentById(int id)
        {
            Comment comment = new Comment();
            return comment.GetCommentById(id);
        }

        Post InterfacePost.GetPostById(int id)
        {
            Post post = new Post();
            return post.GetPostById(id);
        }

        List<Post> InterfacePost.GetPosts()
        {
            Post post = new Post();
            return post.GetAllPosts();
        }

        Comment InterfaceComment.UpdateComment(Comment newComment)
        {
            return newComment.UpdateComment(newComment);
        }

        Post InterfacePost.UpdatePost(Post post)
        {
            return post.UpdatePost(post);
        }

        int InterfaceComment.DeleteComment(Comment comm)
        {
            return comm.DeleteComment(comm.Id);
        }

        Comment InterfaceComment.UpdateOldCommentWithNewOne(Comment oldComment, Comment newComment)
        {
            return newComment.UpdateOldCommentWithNewOne(oldComment, newComment);
        }

        Post InterfacePost.GetPostByTitle(string title)
        {
            Post post = new Post();
            return post.GetPostByTitle(title);
        }

        bool InterfaceComment.AddCommentById(int postId, Comment comment)
        {
            return comment.AddCommentById(postId, comment);
        }
    }
}
