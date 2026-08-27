using BetterErProspecting.Extensions;
using Vintagestory.API.Config;
using Vintagestory.API.Server;

namespace BetterErProspecting.Item.Data;

public class DelayedMessage {
    private int chatGroup = GlobalConstants.InfoLogChatGroup;
    private string message;
    private object[]? args = [];
    public bool externalMod = false;

    internal DelayedMessage(string message, int chatGroup, params object[] args) {
		this.chatGroup = chatGroup;
		this.message = message;
        this.args = args;
    }

    internal DelayedMessage(string message, params object[] args) {
        this.message = message;
        this.args = args;
	}

    internal DelayedMessage(string message) {
		this.message = message;
	}

	public void Send(IServerPlayer sp) {
        args ??= [];
        if (externalMod) {
            message = "!:" + message;
        }

        sp.Info(message, chatGroup, args);
	}
}

