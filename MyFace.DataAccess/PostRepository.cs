using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Npgsql;

namespace MyFace.DataAccess
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetPostsOnWall(string recipient);
        void CreatePost (Post newPost);
        void DeletePost(Post deletePost);
    }

    public class PostRepository : IPostRepository
    {
        public IEnumerable<Post> GetPostsOnWall(string recipient)
        {
            using (var db = ConnectionHelper.CreateSqlConnection())
            {
                return db.Query<Post>("SELECT * FROM Posts WHERE recipient = @recipient", new {recipient});
            }
        }

        public void CreatePost(Post newPost)
        {
            using (var db = ConnectionHelper.CreateSqlConnection())
            {
                db.Query<Post>("INSERT INTO posts (sender, recipient, post_content) VALUES(@sender, @recipient, @post_content);", newPost);
            }
        }

        public void DeletePost(Post currentPost)
        {
            using (var db = ConnectionHelper.CreateSqlConnection())
            {
                var post_id = currentPost.post_id; 
                db.Query<Post>("DELETE FROM Posts WHERE \"post_id\" = @post_id", new { post_id });
            }
        }
    }
}
