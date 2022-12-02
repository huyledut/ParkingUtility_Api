﻿namespace DUTPS.API.Extensions
{
  public static class StringExtensions
  {
    public static string FirstCharToUpper(this string input) =>
        input switch
        {
          null => null,
          "" => "",
          _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
        };
  }
}
