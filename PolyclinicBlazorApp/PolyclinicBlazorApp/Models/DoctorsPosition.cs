using System;
using System.Collections.Generic;

namespace PolyclinicBlazorApp.Models;

public partial class DoctorsPosition
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? PositionId { get; set; }

    public virtual Position? Position { get; set; }

    public virtual User? User { get; set; }
}
