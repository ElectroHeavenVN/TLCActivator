using System;
using System.Collections.Generic;
using System.Threading;
using DiscordRPC;
using TLCActivator.LicenseCheckBypass;

internal class TCLRichPresence
{
    static List<DiscordRpcClient> clients = new List<DiscordRpcClient>();

    static RichPresence CurrentRichPresence => new RichPresence
    {
        Details = GetDetail(),
        State = "Cracked by ElectroHeavenVN",
        Assets = new Assets
        {
            LargeImageKey = GetLargeImageKey(),
            LargeImageText = GetDetail(),
            SmallImageKey = "tcl_smoke",
            SmallImageText = "ThanhLC"
        },
        Buttons = new Button[]
        {
            new Button()
            {
                Label = "Support server",
                Url = "https://dsc.gg/ehvnandfriends"
            },
            new Button()
            {
                Label = "Website ThanhLC",
                Url = "https://thanhlc.com/"
            }
        },
        Type = ActivityType.Watching
    };

    public static void DisposeAllClients()
    {
        foreach (DiscordRpcClient client in clients)
        {
            try
            {
                client.Dispose();
            }
            catch { }
        }
    }

    static void InitClients()
    {
        for (int i = 0; i < 10; i++)
        {
            DiscordRpcClient client = new DiscordRpcClient("1281202426551992380", i);
            client.Initialize();
            clients.Add(client);
        }
    }

    static void SetAllPresence(RichPresence presence)
    {
        foreach (DiscordRpcClient client in clients)
        {
            try
            {
                client.SetPresence(presence);
            }
            catch { }
        }
    }

    public static void Run()
    {
        InitClients();
        DateTime now = DateTime.UtcNow;
        while (true)
        {
            try
            {
                RichPresence presence = CurrentRichPresence;
                if (presence != null)
                {
                    presence.Timestamps = new Timestamps(now);
                    SetAllPresence(presence);
                }
            }
            catch { }
            Thread.Sleep(10000);
        }
    }

    static string GetDetail()
    {
        ToolAssemblyFile toolAssemblyFile = ToolAssemblyFile.GetByProductID(Main.productID);
        if (toolAssemblyFile != null)
            return toolAssemblyFile.RichPresenceDetails;
        return "Activated by TLCActivator";
    }

    static string GetLargeImageKey()
    {
        ToolAssemblyFile toolAssemblyFile = ToolAssemblyFile.GetByProductID(Main.productID);
        if (toolAssemblyFile != null)
            return toolAssemblyFile.RichPresenceLargeImageKey;
        return "icon";
    }
}