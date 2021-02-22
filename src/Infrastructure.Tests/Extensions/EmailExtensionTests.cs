using Infrastructure.Extensions;
using Xunit;

namespace Infrastructure.Tests.Extensions
{
    public class EmailExtensionTests
    {
        [Theory]
        [InlineData("j.s@server1.proseware.com", true)]
        [InlineData("js@contoso.中国", true)]
        [InlineData("david.jones@proseware.com", true)]
        [InlineData("d.j@server1.proseware.com", true)]
        [InlineData("jones@ms1.proseware.com", true)]
        [InlineData("js#internal@proseware.com", true)]
        [InlineData("email@example.com", true)]
        [InlineData("firstname.lastname@example.com", true)]
        [InlineData("email@subdomain.example.com", true)]
        [InlineData("firstname+lastname@example.com", true)]
        [InlineData("\"email\"@example.com", true)]
        [InlineData("1234567890@example.com", true)]
        [InlineData("email@example-one.com", true)]
        [InlineData("_______@example.com", true)]
        [InlineData("email@example.name", true)]
        [InlineData("email@example.museum", true)]
        [InlineData("email@example.co.jp", true)]
        [InlineData("firstname-lastname@example.com", true)]
        [InlineData(@"plainaddress", false)]
        [InlineData(@"#@%^%#$@#$@#.com", false)]
        [InlineData(@"@example.com", false)]
        [InlineData(@"Joe Smith <email@example.com>", false)]
        [InlineData(@"email.example.com", false)]
        [InlineData(@"email@example@example.com", false)]
        [InlineData(@".email@example.com", false)]
        [InlineData(@"email.@example.com", false)]
        [InlineData(@"email..email@example.com", false)]
        [InlineData(@"email@example.com (Joe Smith)", false)]
        [InlineData(@"email@example", false)]
        [InlineData(@"email@-example.com", false)]
        [InlineData(@"email@111.222.333.44444", false)]
        [InlineData(@"email@example..com", false)]
        [InlineData(@"Abc..123@example.com", false)]
        [InlineData("", false)]
        [InlineData(" ", false)]
        [InlineData("   ", false)]
        [InlineData("j.@server1.proseware.com", false)]
        [InlineData("j..s@proseware.com", false)]
        [InlineData("js@proseware..com", false)]
        public void IsValidEmailAddress(string email, bool expected)
        {
            var actual = email.IsValidEmailAddress();

            Assert.Equal(expected, actual);
        }
    }
}
