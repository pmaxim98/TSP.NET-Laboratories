using System.Collections.Generic;

using System.ServiceModel;
using PostComment;

namespace ObjectWCF
{
    [ServiceContract]
    public interface InterfacePost
    {
        [OperationContract]
        bool AddPost(Post post);
        [OperationContract]
        Post UpdatePost(Post post);
        [OperationContract]
        int DeletePost(int id);
        [OperationContract]
        Post GetPostById(int id);
        [OperationContract]
        List<Post> GetPosts();
        [OperationContract]
        Post GetPostByTitle(string title);
    }

    [ServiceContract]
    public interface InterfaceComment
    {
        [OperationContract]
        bool AddComment(Comment comment);
        [OperationContract]
        Comment UpdateComment(Comment newComment);
        [OperationContract]
        Comment GetCommentById(int id);
        [OperationContract]
        int DeleteComment(Comment comm);
        [OperationContract]
        Comment UpdateOldCommentWithNewOne(Comment oldComment, Comment newComment);
        [OperationContract]
        bool AddCommentById(int postId, Comment comment);
    }

    [ServiceContract]
    public interface IPostComment : InterfacePost, InterfaceComment
    {
    }
}
