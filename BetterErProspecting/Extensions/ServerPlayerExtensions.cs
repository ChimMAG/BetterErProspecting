using Vintagestory.API.Config;
using Vintagestory.API.Server;

namespace BetterErProspecting.Extensions;

public static class ServerPlayerExtensions {
    private const string modid = "bettererprospecting";

    public static string L(this IServerPlayer player, string key, params object[] args) {
        return Lang.GetL(player.LanguageCode, prefix(key), args);
    }

    public static void Info(this IServerPlayer player, string message, params object[] args) {
        player.SendLocalized(message, GlobalConstants.InfoLogChatGroup, args);
    }

    public static void Info(this IServerPlayer player, string message, int chatGroup, params object[] args) {
        player.SendLocalized(message, chatGroup, args);
    }

    public static void General(this IServerPlayer player, string message, params object[] args) {
        player.SendLocalized(message, GlobalConstants.AllChatGroups, args);
    }

    public static void SendLocalized(this IServerPlayer player, string message, int groupType, params object[] args) {
        player.SendLocalisedMessage(groupType, prefix(message), args);
    }

    private static string prefix(string message) {
        if (!message.Contains(':')) {
            message = $"{modid}:{message}";
        }

        return message;
    }
}
