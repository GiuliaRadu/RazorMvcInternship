using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RazorMvc.Tests
{
    public class StartupTests
    {
        [Fact]
        public void ShouldConvertUrlToHerokuString()
        {
            //Assume
            string url = "postgres://vnazlwpnrozbap:014c9a59cde8d9c766f45ae85443522623f90953446fdf3ff5140ac6380153ea@ec2-99-80-200-225.eu-west-1.compute.amazonaws.com:5432/deo45t85fqlbta";

            //Act
            var herokuConnectionString = Startup.ConvertDatabaseUrlToHerokuString(url);

            //Assert
            Assert.Equal("Server=ec2-99-80-200-225.eu-west-1.compute.amazonaws.com;Port=5432;Database=deo45t85fqlbta;User Id=vnazlwpnrozbap;Password=014c9a59cde8d9c766f45ae85443522623f90953446fdf3ff5140ac6380153ea;Pooling=true;SSL Mode=Require;Trust Server Certificate=True;", herokuConnectionString);
        }

        [Fact]
        public void ShouldThrowExceptionOnCorruptUrl()
        {
            //Assume
            string url = "Server=127.0.0.1;Port=5432;Database=internshipClass;User Id=internshipClassAdmin;Password=123456";

            //Act & Assert
            var exception = Assert.Throws<FormatException>(() => Startup.ConvertDatabaseUrlToHerokuString(url));
            Assert.StartsWith("Database Url is of invalid format! Check this", exception.Message);
        }
    }
}
