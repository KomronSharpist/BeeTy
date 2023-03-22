using BeeTy.Domain.Entities;
using System.Text.Json.Serialization;

namespace BeeTy.Service.DTOs
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public static explicit operator UserDto(User user)
        {
            return new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                Email = user.Email,
                Phone = user.Phone,
                UserName = user.UserName,
                Password = user.Password
            };
        }
    }
}
