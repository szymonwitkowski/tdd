using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddShop.Cli.Account.Repositories;

namespace TddShop.Cli.Account
{
    public class PasswordValidator : IPasswordValidator
    {
        /// <summary>
        /// Password must meet at least 3 out of the following 4 complexity rules
        ///     at least 1 uppercase character(A-Z)
        ///     at least 1 lowercase character(a-z)
        ///     at least 1 digit(0-9)
        ///     at least 1 special character(punctuation) — do not forget to treat space as special characters too
        ///     at least 10 characters
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsValid(string password)
        {
            var hasUpper = password.Any(p => Char.IsUpper(p));
            var hasLower = password.Any(p => Char.IsLower(p));
            var hasDigit = password.Any(p => Char.IsNumber(p));
            var hasSpecialCharacter = password.Any(p => !(Char.IsNumber(p) || Char.IsLetter(p)));
            var hasAtLeast10characters = true;

            if (password.Length < 10)
            {
                hasAtLeast10characters = false;
            }

            if (hasUpper && hasSpecialCharacter && hasLower && hasDigit && hasAtLeast10characters)
            {
                return true;
            }

            return false;
        }
    }
}