using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SecretSantaE2E.Tests
{
    [TestClass]
    public class EndToEndTests
    {
         private static WebHostServerFixture<SecretSanta.Web.Startup, SecretSanta.Api.Startup> _Server;
        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            Server = new();
        }

        [TestMethod]
        public async Task LaunchHomepage()
        {
            var localhost = _Server.WebRootUri.AbsoluteUri.Replace("127.0.0.1", "localhost");
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });

            var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(localhost);

            Assert.IsTrue(response.Ok);

            var Header = await page.GetTextContentAsync("body > header > div > a");
            Assert.AreEqual("Secret Santa", Header);
        }

        [TestMethod]
        public async Task VerifyUsers()
        {
            var localhost = _Server.WebRootUri.AbsoluteUri.Replace("127.0.0.1", "localhost");
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions
            {
                Headless = true,
            });

            var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(localhost);

            Assert.IsTrue(response.Ok);
            await page.ClickAsync("text=Users");

            var text = await page.GetTextContentAsync("body > section > section > a > section > div");
            Assert.AreEqual("Inigo Montoya", text);
        }

        [TestMethod]
        public async Task VerifyGroups()
        {
            var localhost = _Server.WebRootUri.AbsoluteUri.Replace("127.0.0.1", "localhost");
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions
            {
                Headless = true,
            });

            var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(localhost);

            await page.ClickAsync("text=Groups");
            button = await page.WaitForSelectorAsync("a:has-text('Create Group')");
            Assert.IsNotNull(button);
        }

        [TestMethod]
        public async Task VerifyGifts()
        {
            var localhost = _Server.WebRootUri.AbsoluteUri.Replace("127.0.0.1", "localhost");
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions
            {
                Headless = true,
            });

            var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(localhost);

            await page.ClickAsync("text=Gifts");
            button = await page.WaitForSelectorAsync("a:has-text('Create Gift')");
            Assert.IsNotNull(button);
        }

        [TestMethod]
        public async Task CreateGift()
        {
            var localhost = _Server.WebRootUri.AbsoluteUri.Replace("127.0.0.1", "localhost");
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions
            {
                Headless = true,
            });

            var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(localhost);

            Assert.IsTrue(response.Ok);

            await page.ClickAsync("text=Gifts");

            var giftsList = await page.QuerySelectorAllAsync("body > section > section > section");
            Assert.AreEqual(4, giftsList.Count());

            await page.ClickAsync("text=Create");

            await page.TypeAsync("input#Title", "Test Gift");
            await page.TypeAsync("input#Description", "test description");
            await page.TypeAsync("input#Url", "https://www.test.com");
            await page.TypeAsync("input#Priority", "1");
            await page.SelectOptionAsync("select#UserId", "2");

            await page.ClickAsync("text=Create");

            giftsList = await page.QuerySelectorAllAsync("body > section > section > section");
            Assert.AreEqual(5, giftsList.Count());
        }

        [TestMethod]
        public async Task ModifyLastGift()
        {
            
            var localhost = _Server.WebRootUri.AbsoluteUri.Replace("127.0.0.1", "localhost");
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions
            {
                Headless = true,
            });

            var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(localhost);

            Assert.IsTrue(response.Ok);

            await page.ClickAsync("text=Gifts");

            var text = await page.GetTextContentAsync("body > section > section > section:last-child > a > section > div");
            Assert.AreEqual("Simple Gift", text);

            await page.ClickAsync("body > section > section > section:last-child");

            await page.ClickAsync("input#Title", clickCount:3); // Select all text in the text box
            await page.TypeAsync("input#Title", "TestUpdate Gift");
            await page.ClickAsync("text=Update");

            sectionText = await page.GetTextContentAsync("body > section > section:last-child > a > section > div");
            Assert.AreEqual("TestUpdate Gift", text);
        }

        [TestMethod]
        public async Task DeleteLastGift()
        {
            var localhost = _Server.WebRootUri.AbsoluteUri.Replace("127.0.0.1", "localhost");
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions
            {
                Headless = true,
            });

            var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(localhost);

            Assert.IsTrue(response.Ok);

            await page.ClickAsync("text=Gifts");

            var giftsList = await page.QuerySelectorAllAsync("body > section > section > section");
            var giftCountBeforeDeletion = giftsList.Count();

            page.Dialog += (_, args) => args.Dialog.AcceptAsync();

            await page.ClickAsync("body > section > section > section:last-child > a > section > form > button");
            gifts = await page.QuerySelectorAllAsync("body > section > section");
            Assert.AreEqual(giftsList.Count(), giftCountBeforeDeletion-1);
        }
    }
}
