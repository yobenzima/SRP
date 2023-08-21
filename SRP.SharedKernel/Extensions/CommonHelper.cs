using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SRP.SharedKernel.Extensions;

/// <summary>
/// Represents a common helper.
/// </summary>
public static class CommonHelper
{
    /// <summary>
    /// Gets or sets application default cache time in minutes
    /// </summary>
    public static int CacheTimeInMinutes { get; set; } = 30;
    /// <summary>
    /// Gets or sets application default cookie expires in hours
    /// </summary>
    public static int CookieAuthExpires { get; set; } = 1;

    public static string EnsureSubscriberEmailOrThrow(string email)
    {
        var tOutput = EnsureNotNull(email);
        tOutput = tOutput.Trim();
        tOutput = EnsureMaximumLength(tOutput, 255);

        if(!IsValidEmail(tOutput))
            throw new SRPException("Email is not valid.");

        return tOutput;
    }

    /// <summary>
    /// Verifies that the specified email address string is in a valid format.
    /// </summary>
    /// <param name="email">Email to verify</param>
    /// <returns></returns>
    public static bool IsValidEmail(string email)
    {
        if(String.IsNullOrEmpty(email))
            return false;

        email = email.Trim();
        var tResult = Regex.IsMatch(email, "^(?:[\\w\\!\\#\\$\\%\\&\\'\\*\\+\\-\\/\\=\\?\\^\\`\\{\\|\\}\\~]+\\.)*[\\w\\!\\#\\$\\%\\&\\'\\*\\+\\-\\/\\=\\?\\^\\`\\{\\|\\}\\~]+@(?:(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9\\-](?!\\.)){0,61}[a-zA-Z0-9]?\\.)+[a-zA-Z0-9](?:[a-zA-Z0-9\\-](?!$)){0,61}[a-zA-Z0-9]?)|(?:\\[(?:(?:[01]?\\d{1,2}|2[0-4]\\d|25[0-5])\\.){3}(?:[01]?\\d{1,2}|2[0-4]\\d|25[0-5])\\]))$", RegexOptions.IgnoreCase);
        return tResult;
    }

    /// <summary>
    /// Ensures that the specified string is not longer than maximum length allowed.
    /// </summary>
    /// <param name="input">Input string</param>
    /// <param name="maxLength">Maximum length</param>
    /// <param name="postFix">A string to add to the original string was shortened</param>
    /// <returns>Input string if length is OK; otherwise the truncated input string.</returns>
    public static string EnsureMaximumLength(string input, int maxLength, string postFix = null)
    {
        if(String.IsNullOrEmpty(input))
            return input;

        if(input.Length > maxLength)
        {
            var tPostFixLen = postFix == null ? 0 : postFix.Length;
            
            var tResult = input[..(maxLength - tPostFixLen)];
            if(!String.IsNullOrEmpty(tResult))
               return input[..(maxLength)];

            if(!String.IsNullOrEmpty(postFix))
                tResult += postFix;

            return tResult;
        }

        return input;
    }

    public static string EnsureSubscriberNameOrThrow(string name)
    {
        if(string.IsNullOrEmpty(name))
            throw new ArgumentNullException(nameof(name));

        return name;
    }

    public static string EnsureSubscriberPasswordOrThrow(string password)
    {
        if(string.IsNullOrEmpty(password))
            throw new ArgumentNullException(nameof(password));

        return password;
    }

    public static string EnsureNotNull(string value)
    {
        return (string.IsNullOrEmpty(value) || (value == string.Empty)) ? string.Empty : value;
    }

    /// <summary>
    /// Generates a random string with the given length.
    /// </summary>
    /// <param name="length"></param>
    /// <returns></returns>
    public static string GenerateRandomStringCode(int length)
    {
        var tRandom = new Random();
        var tBuilder = new StringBuilder();
        for(var i = 0; i < length; i++)
        {
            var tInt = tRandom.Next(33, 126);
            tBuilder.Append((char)tInt);
        }

        return tBuilder.ToString();
    }
    /// <summary>
    /// Generates a random string with the given length.
    /// </summary>
    /// <param name="length"></param>
    /// <returns></returns>
    public static string GenerateRandomDigitCode(int length)
    {
        var tResult = string.Empty;
        using var tRandom = RandomNumberGenerator.Create();
        var tBytes = new byte[length];
        tRandom.GetBytes(tBytes);
        foreach(var tByte in tBytes)
            tResult = String.Concat(tResult, tByte);

        return tResult;
    }

    /// <summary>
    /// Gets the description of an enum value.
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static string GetEnumDescription<TEnum>(TEnum value)
    {
        if(value == null)
            throw new ArgumentNullException(nameof(value));

        var tFieldInfo = value.GetType().GetField(value.ToString()!);
        if(tFieldInfo == null)
            return value.ToString()!;
        var tAttributes = (DescriptionAttribute[])tFieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

        return tAttributes!.Length > 0 ? tAttributes[0]!.Description : value.ToString()!;
    }

    /// <summary>
    /// Generates a random integer with the given length.
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static int GenerateRandomInteger(int min = 0, int max = int.MaxValue)
    {
        var tRandomNumberBuffer = new byte[10];
        RandomNumberGenerator.Create().GetBytes(tRandomNumberBuffer);
        return new Random(BitConverter.ToInt32(tRandomNumberBuffer, 0)).Next(min, max);
    }

    /// <summary>
    /// Compares two arrays of the same type.
    /// </summary>
    /// <typeparam name="T">Type parameter</typeparam>
    /// <param name="a1">Array 1</param>
    /// <param name="a2">Array 2</param>
    /// <returns>True if the same else False</returns>
    public static bool ArraysEquals<T>(T[] a1, T[] a2)
    {
        // If both are null, or both are same instance, return true.
        if(a1 == null && a2 == null)
            return true;

        // If one is null, but not both, return false.
        if(a1 == null || a2 == null)
            return false;

        // The arrays must be the same length, if different, return false. No need to check the elements.
        if(a1.Length != a2.Length)
            return false;

        // Create comparer
        var tComparer = EqualityComparer<T>.Default;

        // Loop through arrays.
        for(var i = 0; i < a1.Length; i++)
            // If looped elements are not equal, arrays are not equal.
            if(!tComparer.Equals(a1[i], a2[i]))
                return false;

        return true;
    }
    /// <summary>
    /// Checks if the given type is a simple type.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static bool IsSimpleType(Type type)
    {
        if(type == null)
            return true;

        return
            type.IsPrimitive ||
            new[]
            {
                typeof(string),
                typeof(decimal),
                typeof(DateTime),
                typeof(DateTimeOffset),
                typeof(TimeSpan),
                typeof(Guid)
            }.Contains(type) ||
            type.IsEnum ||
            Convert.GetTypeCode(type) != TypeCode.Object ||
            (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>) && IsSimpleType(type.GetGenericArguments()[0]));
    }
}
