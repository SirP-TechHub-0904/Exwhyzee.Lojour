using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Exwhyzee.Enums
{
    public enum EntityStatus
    {
        [Description("Active")]
        Active = 1,

        [Description("Deleted")]
        Deleted = 2,

        [Description("Pending")]
        Pending = 3,

        [Description("Success")]
        Success = 4,

        [Description("Failed")]
        Failed = 5,

        [Description("Processing")]
        Processing = 6,

        [Description("Drawn")]
        Drawn = 7,

        [Description("Closed")]
        Closed = 8,
    }

    public enum PropertyStatus
    {
        [Description("None")]
        None = 0,
        [Description("Active")]
        Active = 1,
        [Description("Bidding")]
        Bidding = 2,
        [Description("Sold")]
        Sold = 3,
        [Description("Pending")]
        Pending = 4,
        [Description("Delete")]
        Delete = 5,



    }

    public enum HomeLocation
    {
        [Description("None")]
        None = 0,
        [Description("MajorMain")]
        MajorMain = 1,
        [Description("MinnorMain")]
        MinnorMain = 2,
        [Description("List")]
        List = 3,
        
    }

    public enum PagePosition
    {
        [Description("None")]
        None = 0,
        [Description("Head")]
        Head = 1,
        [Description("Footer")]
        Footer = 2,
        [Description("Last Footer")]
        LastFooter = 3,

    }

    public enum PageStatus
    {
        [Description("None")]
        None = 0,
        [Description("Active")]
        Active = 1,
        [Description("Disabled")]
        Disabled = 2

    }

    public enum VerificationStatus
    {
        [Description("None")]
        None = 0,
        [Description("Verified")]
        Verified = 1,

        [Description("Not Verified")]
        NotVerified = 2,



    }

    public enum DescriptiveStatus
    {
        [Display(Description = "None")]
        None = 0,
        [Display(Description = "For Rent")]
        ForRent = 1,

        [Display(Description = "For Sale")]
        ForSale = 2,

        [Display(Description = "Short Let")]
        ShortLet = 3,

    }

    public enum SmsStatusEnum
    {
        [Description("Sent")]
        Sent = 1,

        [Description("Pending")]
        Pending = 2,

        [Description("Not Sent")]
        NotSent = 3,

    }

    public enum AgentStatusEnum
    {
        [Description("Approved")]
        Approved = 1,

        [Description("Pending")]
        Pending = 2,

    }

    public enum ModeOfId
    {
        [Description("None")]
        None = 0,

        [Description("Driver Licence")]
        DriverLicence = 1,

        [Description("National Id")]
        NationalId = 2,
        [Description("International Passport")]
        InternationalPassport = 3,

    }

    public enum UserVerification
    {
        [Description("Verified")]
        Verified = 1,

        [Description("Unverified")]
        Unverified = 2,

    }

    public enum PayoutEnum
    {
        [Description("PayedToBank")]
        PayedToBank = 1,

        [Description("Pending")]
        Pending = 2,
        [Description("PayedToWallet")]
        PayedToWallet = 3,

    }

    public enum SideBarnerEnum
    {
        [Description("none")]
        none = 0,


        [Description("Side Bar Big")]
        SideBarBig = 10,

        [Description("Side Bar Small")]
        SideBarSmall = 20,

        [Description("Winning Location")]
        WinningLocation = 30,

    }
}
