using BeeTy.Domain.Commons;
using BeeTy.Domain.Enums;

namespace BeeTy.Domain.Entities;

public class Plan : Auditable
{
    public int UserId { get; set; }
    public User User { get; set; }
    public int WorkerId { get; set; }
    public Worker Worker { get; set; }
    public string Description { get; set; }
    public OrderTypes statusType { get; set; } = OrderTypes.planned;
}
