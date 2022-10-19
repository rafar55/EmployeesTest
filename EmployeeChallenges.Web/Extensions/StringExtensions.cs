namespace EmployeeChallenges.Web.Extensions;

public static class StringExtensions
{
    //Using Goggles Libphonenumber library in order to fomat the phone number correctly
    public static string FormatPhoneNumber(this string str)
    {
        var phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
        var phoneNumber = phoneNumberUtil.Parse(str,"US");
        return phoneNumberUtil.Format(phoneNumber, PhoneNumbers.PhoneNumberFormat.NATIONAL);
    }
}
