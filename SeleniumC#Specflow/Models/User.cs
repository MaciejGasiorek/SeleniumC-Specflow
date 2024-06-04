using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NUnit.Framework.Internal.OSPlatform;

namespace SeleniumCsharpSpecflow.Models
{
    public class User
    {
        [RegularExpression("^([a-zA-Z]{2,}\\s[a-zA-Z]{1,}'?-?[a-zA-Z]{2,}\\s?([a-zA-Z]{1,})?)", ErrorMessage = "Valid Charactors include (A-Z) (a-z) (' space -)")]
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Country { get; set; }

        [RegularExpression(@"^(?-i:A[LKSZRAEP]|C[AOT]|D[EC]|F[LM]|G[AU]|HI|I[ADLN]|K[SY]|LA|M[ADEHINOPST]|N[CDEHJMVY]|O[HKR]|P[ARW]|RI|S[CD]|T[NX]|UT|V[AIT]|W[AIVY])$", ErrorMessage = "Invalid State")]
        public string State { get; set; }

        [RegularExpression(@"^[a-zA-Z\s]+$")]
        public string City { get; set; }

        [RegularExpression(@"^\d{4}$")]
        public string Zipcode { get; set; }
        [RegularExpression(@"^\d{7}$")]
        public string MobileNumber { get; set; }
       
    }
}
