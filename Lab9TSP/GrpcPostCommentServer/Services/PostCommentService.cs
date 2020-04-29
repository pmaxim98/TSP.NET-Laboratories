using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

using GrpcPostComment;
using PostComment;

namespace GrpcGreeter
{
    public class PostCommentService : gRPCPostCommentService.gRPCPostCommentServiceBase
    {
        private readonly ILogger<PostCommentService> _logger;
        public PostCommentService(ILogger<PostCommentService> logger)
        {
            _logger = logger;
        }

        public override Task<PostsResponse> GetAllPosts(NoParamsMessage noParamsMessage, ServerCallContext context)
        {
            return Task.FromResult(new PostsResponse()
            {
                Posts = { EntitiesPostsToMessagesPosts(new Post().GetAllPosts()) }
            });
        }

        public override Task<PostMessage> GetPostById(IdMessage idMessage, ServerCallContext context)
        {
            return Task.FromResult(EntityPostToMessagePost(new Post().GetPostById(idMessage.Id)));
        }

        public override Task<PostMessage> SubmitPost(PostMessage postMessage, ServerCallContext context)
        {
            Post addedPost = MessagePostToEntityPost(postMessage).AddPost();

            return Task.FromResult(EntityPostToMessagePost(addedPost));
        }

        public override Task<PostMessage> UpdatePost(PostMessage postMessage, ServerCallContext context)
        {
            Post updatedPost = new Post().UpdatePost(MessagePostToEntityPost(postMessage));

            return Task.FromResult(EntityPostToMessagePost(updatedPost));
        }

        public override Task<BoolMessage> DeletePost(IdMessage idMessage, ServerCallContext context)
        {
            return Task.FromResult(new BoolMessage
            {
                Value = new Post().DeletePost(idMessage.Id) != 0
            });
        }

        public override Task<CommentMessage> GetCommentById(IdMessage idMessage, ServerCallContext context)
        {
            return Task.FromResult(EntityCommentToMessageComment(new Comment().GetCommentById(idMessage.Id)));
        }

        public override Task<NoParamsMessage> DeleteComment(CommentMessage commentMessage, ServerCallContext context)
        {
            new Comment().DeleteComment(commentMessage.Id);

            return Task.FromResult(new NoParamsMessage());
        }

        public override Task<BoolMessage> SubmitComment(CommentMessage commentMessage, ServerCallContext context)
        {
            bool added = MessageCommentToEntityComment(commentMessage).AddComment();

            return Task.FromResult(new BoolMessage
            {
                Value = added
            });
        }

        public PostMessage EntityPostToMessagePost(Post post)
        {
            PostMessage postMessage = new PostMessage
            {
                PostId = post.PostId,
                Description = post.Description,
                Domain = post.Domain,
                Date = post.Date
            };

            foreach (Comment comment in post.Comments)
                postMessage.Comments.Add(EntityCommentToMessageComment(comment));

            return postMessage;
        }

        public CommentMessage EntityCommentToMessageComment(Comment comment)
        {
            return new CommentMessage
            {
                Id = comment.Id,
                Text = comment.Text,
                PostPostId = comment.PostPostId,
                Post = EntityPostToMessagePost(comment.Post)
            };
        }

        public List<PostMessage> EntitiesPostsToMessagesPosts(List<Post> posts)
        {
            List<PostMessage> postMessages = new List<PostMessage>();

            foreach (Post p in posts)
                postMessages.Add(EntityPostToMessagePost(p));

            return postMessages;
        }

        public Post MessagePostToEntityPost(PostMessage postMessage)
        {
            Post post = new Post
            {
                PostId = postMessage.PostId,
                Description = postMessage.Description,
                Domain = postMessage.Domain,
                Date = postMessage.Date
            };

            foreach (CommentMessage commentMessage in postMessage.Comments)
                post.Comments.Add(MessageCommentToEntityComment(commentMessage));

            return post;
        }

        public Comment MessageCommentToEntityComment(CommentMessage commentMessage)
        {
            return new Comment
            {
                Id = commentMessage.Id,
                Text = commentMessage.Text,
                PostPostId = commentMessage.PostPostId,
                Post = MessagePostToEntityPost(commentMessage.Post)
            };
        }
    }
}
