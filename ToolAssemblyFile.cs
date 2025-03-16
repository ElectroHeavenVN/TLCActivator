﻿using System;
using System.Linq;

internal class ToolAssemblyFile
{
    public string ExecutableName { get; set; }

    public string ProductID { get; set; }

    public string ProductType { get; set; }

    public string OriginalHash { get; set; }

    public string DeobfuscatedHash { get; set; }

    public string RelativeGameAssemblyPath { get; set; }

    public string OriginalGameAssemblyHash { get; set; }

    public string ModifiedGameAssemblyHash { get; set; }

    public string RichPresenceDetails { get; set; }

    public string RichPresenceLargeImageKey { get; set; }

    public ToolAssemblyFile(string executableName, string productID, string productType, string originalHash, string deobfuscatedHash, string relativeGameAssemblyPath, string originalGameAssemblyHash, string modifiedGameAssemblyHash, string richPresenceDetails, string richPresenceLargeImageKey)
    {
        ExecutableName = executableName;
        ProductID = productID;
        ProductType = productType;
        OriginalHash = originalHash;
        DeobfuscatedHash = deobfuscatedHash;
        RelativeGameAssemblyPath = relativeGameAssemblyPath;
        OriginalGameAssemblyHash = originalGameAssemblyHash;
        ModifiedGameAssemblyHash = modifiedGameAssemblyHash;
        RichPresenceDetails = richPresenceDetails;
        RichPresenceLargeImageKey = richPresenceLargeImageKey;
    }

    public static ToolAssemblyFile[] tools = new ToolAssemblyFile[]
    {
        new ToolAssemblyFile(
            "[ThanhLc] QLTK Dragon Ball Pro",
            "DRAGONBALLPRO237",
            "thanhlcpropc",
            "BB2017027BD16886E8B18C0E18F83EF5B4B1A4EE327AB6F273C54252B0BB3BF4",
            "",
            @"Dragon ball_237b_Data\Managed\Assembly-CSharp.dll",
            "",
            "6F901FA6CE32AEAB438F29EEF7F631523EF50CE8B0B7D824293CE766F07A4BF2",
            "Dragon Ball Pro 2.3.7 v2.0",
            "icon_dboprov2"
            ),
        new ToolAssemblyFile(
            "[ThanhLc] Tool hỗ trợ up đệ tử thường",
            "AUTOPET225",
            "toolpet",
            "D335BAAD5BA814DE163FA46530AB2B0196BD7907188F6FB7EE05BDA540799A33",
            "",
            @"lib\DragonPro225.jar",
            "",
            "858090296A0827CD9C9D02605C31EE29A00ADEC3B73F9C8998D3E4E4312A4858",
            "Tool hỗ trợ up đệ tử Java",
            "icon_updejava"
            ),
        new ToolAssemblyFile(
            "[ThanhLc] Tool hỗ trợ up đệ tử",
            "AUTOPET237",
            "tooldetupro",
            "DED795B8785EF0F3BC3C4D41AC679738595EE70E10599256D9A0CF363E0EBCAE",
            "",
            @"Dragon ball_237b_Data\Managed\Assembly-CSharp.dll",
            "",
            "78A91B2860218EBE36B69BCE4B85CB763DBE111E7BA9C1E6E6C298EEB4D77ADE",
            "Tool hỗ trợ up đệ tử Pro",
            "icon_updepro"
            ),
        new ToolAssemblyFile(
            "[ThanhLc] Tool up set kích hoạt",
            "TOOLUPSKH",
            "toolupskh",
            "4DB339DDA0FA261DF3779ACB62E90006E347DE6A75885F91BDE218290CF20CCD",
            "",
            @"Dragon ball_237b_Data\Managed\Assembly-CSharp.dll",
            "",
            "7151AAD00F42CB07A4E70E2F6E3E30A83378917094D4F984A8AF38821CD252F8",
            "Tool up Set Kích hoạt",
            "icon_upskh"
            ),
        new ToolAssemblyFile(
            "[ThanhLc] Tool train tuyệt kỹ",
            "TRAINSKILL9",
            "tooltrainskill",
            "AA6BB9C92E0FFDB16DC06E606B34B6C44D32F41057C7FC8C531A8A4C84D36AC3",
            "",
            @"Dragon ball_237b_Data\Managed\Assembly-CSharp.dll",
            "",
            "85782F2B9464FDAA5928F32717A973E168D54C25B0CCBFFBCF9E0DAEAA5F6C1A",
            "Tool Train Skill 9",
            "icon_trainskill9"
            ),
        new ToolAssemblyFile(
            "[ThanhLc] Tool nhiệm vụ bò mộng",
            "AUTONVBM",
            "toolnvhangngaypro",
            "1B0F244595BCEC8261B462D4DDF62B82325554BCD0B68F03EC1B534174584B97",
            "",
            @"Dragon ball_237b_Data\Managed\Assembly-CSharp.dll",
            "",
            "F2BDD8C88B44041159BEA2844AC6E05B9E184573F856A0A3BD1EA8039C997FEF",
            "Tool nhiệm vụ hàng ngày",
            "icon_nvbm"
            ),
        new ToolAssemblyFile(
            "[ThanhLc] Tool up mảnh vỡ bông tai",
            "PORATASHARP237",
            "toolmvbt",
            "FE675CDA901DCA913FC88FF7353219AA51BF782A7722FCB8ABAA76DED05B1FCE",
            "",
            @"Dragon ball_237b_Data\Managed\Assembly-CSharp.dll",
            "",
            "BE60311F1253A53FFC5E1D0CF288C84943066F740105204BAC46177FB3B73AB0",
            "Tool up mảnh vỡ bông tai",
            "icon_mvbt"
            ),
        new ToolAssemblyFile(
            "[ThanhLc] Tool Godzilla và Kong",
            "GODZILLAANDKONG",
            "toolgodzillaandkong",
            "E2E9893F50A4EF354C830DE599035F74EDAFD6064D9AA7D98C4627302E4035D4",
            "",
            @"Dragon ball_237b_Data\Managed\Assembly-CSharp.dll",
            "",
            "8ECD74A494C577B1868CEF746CB9FA430947E09648EB8B333C738999D934B868",
            "Tool Godzilla và Kong",
            "icon_godzkong"
            ),
        new ToolAssemblyFile(
            "[ThanhLc] Tool treo giáp tập luyện",
            "TREOGTL",
            "TOOL_TRAIN_SUIT_TIME",
            "FDB3691FD8AA1C946AF17C52581E803F5BACCEDD74292FA0B329B5B7071F4CFD",
            "96F3077CFFE06F3A6CF808464C225009D63F9A970D070B27A4E43468A72226F4",
            @"Dragon ball_237b_Data\Managed\Assembly-CSharp.dll",
            "",
            "3A979F4B310BB897170C109427836F428448E5BFAE02FA06316B1F8E9062867D",
            "Tool treo Giáp tập luyện",
            "icon_treogtl"
            ),
        new ToolAssemblyFile(
            "[LCT] QLTK Ultra Pro 244",
            "ULTRA_PRO_244_20/2/2024",
            "ULTRA_PRO_244",
            "A05D78A205F33592F06F77F0E91AA4CD2E15FFE312CB7E61CFCEFD8A9FE0AEBC",
            "E9735F94AB6A8F06C7D95A078AEFDD91AB115A655614A476ACB4C10AB8CCA2B2",
            @"Nro_244_Data\Managed\Assembly-CSharp.dll",
            "",
            "5EAFAF76A76F9D288BB74A117BC6BD524FAEFCC2453E480B3C5C3C97F814DCFB",
            "Dragon Boy Ultra Pro 2.4.4",
            "icon_ultrapro"
            ),
        new ToolAssemblyFile(
            "[ThanhLc] Tool train quái",
            "TOOLTRAINQUAIV1",
            "TOOL_FARM_MOB",
            "22F9425AE7D5140638A5C49D86E41820E99AF7A60E6E1D41C2EED62AB0E27D72",
            "8FF61F47F73D1D30436599D42F5F32D65C1535120B53DEDF40D9004296879941",
            @"Dragon ball_237b_Data\Managed\Assembly-CSharp.dll",
            "3430ECC1F737B28CCB2884E9B4D5542F7C7BB03A5044EBBFD027523B55FC65C9",
            "2ED8F054CDDF24C993A403651AD53BD5D01BF4852FE170156AAFB376454A49FB",
            "Tool Train Quái",
            "icon_trainquaiv1"
            ),
        new ToolAssemblyFile(
            "[ThanhLc] Tool nhiệm vụ bò mộng",
            "AUTONVBM",
            "TOOL_BORA_DAILY_TASK",
            "885D8A01404489C0EFDDB42B345830C4FEAE72DA3C3D142E26C2D0FB71CD4003",
            "BEF01C4485F4389A74620097928052A2396DC680A859F0D1D487789ED368F521",
            @"Dragon ball_237b_Data\Managed\Assembly-CSharp.dll",
            "",
            "0614E159198605E072816CCC2A36F69DB7EC1A0C812E4CC01E219852226ACE36",
            "Tool nhiệm vụ hàng ngày",
            "icon_nvbm"
            ),
    };

    public static ToolAssemblyFile GetByProductID(string productID) => tools.FirstOrDefault(x => x.ProductID == productID);

    public static bool HashMatch(string hash) => tools.Any(x => x.OriginalHash == hash || x.DeobfuscatedHash == hash);

    public static bool GameAssemblyHashMatch(string hash) => tools.Any(x => x.OriginalGameAssemblyHash == hash || x.ModifiedGameAssemblyHash == hash);

    public static string[] GetProductIDs() => tools.Select(x => x.ProductID).ToArray();
}
