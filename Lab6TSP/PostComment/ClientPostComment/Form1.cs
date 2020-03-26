using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using PostComment;

namespace ClientPostComment
{
    public partial class Form1 : Form
    {
        List<Post> posts = new List<Post>();

        int selectedPostIndex = -1;

        public Form1()
        {
            InitializeComponent();

            RefreshPosts();

            dgp.CellMouseClick += dgp_CellMouseClick;

            dgp.Columns[0].Width = 0;

            if (dgp.Rows.Count > 0)
                dgc.DataSource = posts[0].Comments;
        }

        private void RefreshPosts()
        {
            posts = LoadPosts().ToList();
            dgp.DataSource = posts;
        }
        
        private void RefreshComments(int rowIndex)
        {
            dgc.DataSource = null;
            dgc.DataSource = posts[rowIndex].Comments;
        }

        private static Post[] LoadPosts()
        {
            PostCommentClient pc = new PostCommentClient();
            return pc.GetPosts();
        }

        private void dgp_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            selectedPostIndex = e.RowIndex;
            RefreshComments(e.RowIndex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PostCommentClient pc = new PostCommentClient();

            bool added = pc.AddPost(new Post 
            { 
                Description = textBoxDesc.Text,
                Date = textBoxDate.Text,
                Domain = textBoxDomain.Text
            });

            if (added)
                RefreshPosts();
        }

        private void buttonAddComment_Click(object sender, EventArgs e)
        {
            if (selectedPostIndex < 0)
                return;

            PostCommentClient pc = new PostCommentClient();

            Post selectedPost = posts[selectedPostIndex];

            Comment comment = new Comment()
            {
                Text = textBoxComment.Text,
                PostPostId = selectedPost.PostId
            };

            pc.AddComment(comment);

            RefreshPosts();
            RefreshComments(selectedPostIndex);
        }
    }
}
