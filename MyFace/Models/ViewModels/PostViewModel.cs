﻿using MyFace.DataAccess;

namespace MyFace.Models.ViewModels
{
    public class PostViewModel:User
    {
        public string sender { get; }
        public string recipient { get; }
        public string post_content { get; }

        public PostViewModel(Post post)
        {
            sender = post.sender;
            recipient = post.recipient;
            post_content = post.post_content;
        }
    }
}