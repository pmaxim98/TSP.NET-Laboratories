using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PostComment
{
    [DataContract(IsReference = true)]
    public partial class CommentDTO
    {
        [DataMember]
        public int CommentId { get; set; }
        [DataMember]
        public string CommentText { get; set; }
        [DataMember]
        public int PostId { get; set; }
        [DataMember]
        public int PostPostId { get; set; }
        [DataMember]
        public virtual PostDTO Post { get; set; }
    }

    [DataContract]
    public partial class PostDTO
    {
        public PostDTO()
        {
            this.Comments = new List<CommentDTO>();
        }
        [DataMember]
        public int PostId { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public virtual List<CommentDTO> Comments { get; set; }
    }

    [ServiceContract]
    public interface IPost
    {
        [OperationContract]
        void Cleanup();
        [OperationContract]
        PostDTO GetPostById(int id);
        [OperationContract]
        PostDTO GetPostByTitle(string title);
        // Insert, Update, Delete Post
        [OperationContract]
        PostDTO SubmitPost(PostDTO post);
        [OperationContract]
        PostDTO UpdatePost(PostDTO newPost);
        [OperationContract]
        bool DeletePost(int postId);
        [OperationContract]
        List<PostDTO> GetAllPosts();
    }

    [ServiceContract]
    public interface IComment
    {
        // Insert, Update, Delete Comment
        [OperationContract]
        CommentDTO GetCommentById(int id);
        [OperationContract]
        CommentDTO SubmitComment(CommentDTO comment);
        [OperationContract(Name = "AddCommment")]
        CommentDTO SubmitComment(int postId, CommentDTO comment);
        [OperationContract]
        CommentDTO UpdateComment(CommentDTO oldComment, CommentDTO newComment);
        [OperationContract]
        bool DeleteComment(int commentId);
    }

    [ServiceContract]
    public interface ILoadData
    {
        [OperationContract]
        List<PostDTO> GetAllPostsAndRelatedComments();
    }

    [ServiceContract]
    public interface IPostComment : IPost, IComment, ILoadData
    { }
}
