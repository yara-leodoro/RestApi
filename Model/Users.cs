using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTApi.Model
{
    [Table("users")]
    public class Users
    {

        [Key]
        [Column("id")]
        public long Id {get; set;}

        [Column("user_name")]
        public string UserName {get; set;}

        [Column("full_name")]
        public string FullName {get; set;}

        [Column("password")]
        public string Password {get; set;}

        [Column("refresh_token")]
        public string RefreshToken {get; set;}

        [Column("resfresh_token_expiry_time")]
        public DateTime ResfreshTokenExpiryTupe {get; set;}
    }
}