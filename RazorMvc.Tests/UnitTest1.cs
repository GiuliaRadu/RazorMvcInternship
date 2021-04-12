using System;
using Xunit;
using RazorMvc.Services;
using RazorMvc.Models;

namespace RazorMvc.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void InitiallyContainsThreeMembers()
        {
            // Assume
            var intershipService = new InternshipService();

            // Act

            // Assert
            Assert.Equal(3, intershipService.GetMembers().Count);
        }

        [Fact]
        public void WhenAddMemberItShouldBeThere()
        {
            // Assume
            var intershipService = new InternshipService();

            // Act
            Intern memberToAdd = new Intern();
            memberToAdd.Name = "Marko";
            intershipService.AddMember(memberToAdd);

            // Assert
            Assert.Equal(4, intershipService.GetMembers().Count);
            Assert.Contains(memberToAdd, intershipService.GetMembers());
        }
    }
}
