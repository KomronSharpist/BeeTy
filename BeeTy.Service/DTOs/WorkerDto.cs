using BeeTy.Domain.Entities;
using System.Text.Json.Serialization;

namespace BeeTy.Service.DTOs
{
    public class WorkerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public static explicit operator WorkerDto(Worker worker)
        {
            return new WorkerDto
            {
                FirstName = worker.FirstName,
                LastName = worker.LastName,
                Email = worker.Email,
                Phone = worker.Phone,
                UserName = worker.UserName,
                Password = worker.Password,
            };
        }
    }
}
