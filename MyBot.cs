// // <copyright file="MyBot.cs" company="CodePlus Software">
// // Copyright(c) 2024 All Right Reserved
// // </copyright>
// // <author>Szymon Hełmecki</author>
// // <date>20-06-2024</date>
// // <summary>MyBot.cs</summary>

using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace TestBotBackend;

public class EchoBot : ActivityHandler
{
  protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
  {
    var replyText = $"Echo: {turnContext.Activity.Text}";
    await turnContext.SendActivityAsync(MessageFactory.Text(replyText, replyText), cancellationToken);
  }

  protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
  {
    foreach (var member in membersAdded)
    {
      if (member.Id != turnContext.Activity.Recipient.Id)
      {
        await turnContext.SendActivityAsync(MessageFactory.Text("Welcome to the bot!"), cancellationToken);
      }
    }
  }
}