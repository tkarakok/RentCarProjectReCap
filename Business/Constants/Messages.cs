using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Car added";
        public static string CarAddFailed = "Car didn't add";
        public static string ImagesListedById = "Car Images Listed !";
        public static string ImageAdded = "Car Image Added";
        public static string ImageUpdated = "Car Image Updated !";
        public static string CarImageLimitReached = "Car Image Limit Reached";
        public static string UserNotFound = "User Not Found";
        public static string PasswordError = "Wrong password!";
        public static string SuccessfulLogin = "Login successful";
        public static string UserAlreadyExists = "User Already Exists";
        public static string UserRegistered = "User registered succesful";
        public static string AccessTokenCreated = "Access Token Created";
    }
}
