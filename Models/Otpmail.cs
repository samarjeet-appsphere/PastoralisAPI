using System;
using System.Collections.Generic;

namespace Pastorials.Models;

public partial class Otpmail
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? Otp { get; set; }
}
