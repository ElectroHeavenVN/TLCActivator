using System;
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
            "4A672D0659D2F5EF4E1C643683B44761FC21304CD454493F8C6B5478FF8BE39A",
            @"Dragon ball_237b_Data\Managed\Assembly-CSharp.dll",
            "4A8A3AFEB36D41F3D0256BA5A7CD10C8F79C55D0A5FF87E6CBEB913A941180FC",
            "8057A5B8CC0CF451138B9932B6BBC2A1A179EE7FCAD292AABE3C34E0148C7367",
            "Tool treo Giáp tập luyện",
            "icon_treogtl"
            ),
        new ToolAssemblyFile(
            "[LCT] QLTK Ultra Pro 244",
            "ULTRA_PRO_244_20/2/2024",
            "ULTRA_PRO_244",
            "064769B2407B0FC24980CEE31A05583EA5B8E1EF136CC9BB50443A9A4F9F57DD",
            "7623FCE3F50D3B51698DE4A44E85B3C72FED671978C0FE088346DC9E96D4B885",
            @"Nro_244_Data\Managed\Assembly-CSharp.dll",
            "B9E2BDE1B86C1160B9D85D4234ABCC92DA61B4F07627E3F8BA1DAC9FBC1EB7FF",
            "4E169546F3251F4CEC6FB3BEDC246A78FF3D4A6CABF63213E1C8CCC31A56BFA2",
            "Dragon Boy Ultra Pro 2.4.4",
            "icon_ultrapro"
            ),
        new ToolAssemblyFile(
            "[ThanhLc] Tool train quái",
            "TOOLTRAINQUAIV1",
            "TOOL_FARM_MOB",
            "73FE67096284241ACBEE7EF9CB4F33F41B3F09F54AE602214DCCD7562A20B468",
            "5846275CEFD490A86199385FEF55F8EAB8847CBAE780A6E5068D517D96716C4D",
            @"Dragon ball_237b_Data\Managed\Assembly-CSharp.dll",
            "26F99DC7F4BE24A076CD9CB05D322B37C168C992C1F31CC084787DF52406AA98",
            "3761D9877D3C1C4C51F70EE97E562AFCE434672F992E0B711A58E4B9128E959A",
            "Tool Train Quái",
            "icon_trainquaiv1"
            ),
        new ToolAssemblyFile(
            "[ThanhLc] Tool nhiệm vụ bò mộng",
            "AUTONVBM",
            "TOOL_BORA_DAILY_TASK",
            "C63C68DFC2A796D45814B6925F92F58D5686F75A63E1FF47210C4D990B7B3042",
            "0A10E4A23B278D123210DCADE252747E832202F3153D65C08CDB651D01B597BD",
            @"Dragon ball_237b_Data\Managed\Assembly-CSharp.dll",
            "9E2F4C6B9A07A15CC332E4DB48008F48E1A4DF26C8AE059E843C7010B81CFAF1",
            "25C39CF37FD9689B9203D7CDE9C08355CC182536CA78586F4F42C7E214C32FCD",
            "Tool nhiệm vụ hàng ngày",
            "icon_nvbm"
            ),
        new ToolAssemblyFile(
            "[ThanhLc] Tool nhặt ngọc hàng ngày",
            "PICKGEM237",
            "TOOL_PICK_UP_GEM",
            "F22FC8ADF12CFEADB3CFD1DFD91BAFE85DFDF4C9B2BD01670AAE4678E5390533",
            "9E66AC730C5E4E369A34C8ED6DC9A910459C3719C93B29A4C8E6B933B00CBE73",
            @"Dragon ball_237b_Data\Managed\Assembly-CSharp.dll",
            "A551F593F083048D6CDB217BABB97B64038BF9487D518AC55706424EF2CF66F1",
            "C1C3E7A28AE3D707569F65E28588EC28AE4B7F8C7BDEBCE6D0380EE174ED754C",
            "Tool nhặt ngọc hàng ngày",
            "icon_pickgem"
            ),
        new ToolAssemblyFile(
            "[ThanhLc] Tool hỗ trợ up đệ tử V2",
            "AUTOPET225_18/10/2024",
            "TOOL_TRAIN_DISCIPLE_JAVA2",
            "BF94157575D475F7BC1FDCFB7C7B985959BEA81DE3F35479A2853D6B16E05425",
            "C034364DBF212537F0EC45398150214B6EAFF3E1CEC513F55E373A21410C0632",
            @"lib\DragonPro225.jar",
            "F72E60E30506CEC47A5BEDCCCADA2D34EEB76374C1FE669F74F7F84AC5D06693",
            "1B533AEEF415EE9B1ECDE7059174FCF6A6C2318A7F32FA20E90A7672294AA271",
            "Tool hỗ trợ up đệ tử Java",
            "icon_updejava"
            ),
        new ToolAssemblyFile(
            "[ThanhLc] Tool tự động bán đồ rác",
            "CLEANINVENTORY",
            "TOOL_CLEAN_INVENTORY",
            "179AC7781F3AF72715C72214A27FF81E1FFFDA61ABEE5F18914EBD3FEF2C6DA5",
            "645F16A2F94DE338B90C67AE58CEC6F982B7CB7CC3BF8369CF97023A4DB6CAF9",
            @"Dragonboy_vn_v231_Data\Managed\Assembly-CSharp.dll",
            "93F8144C43917FA5F5A44C098171C49CAA3A472894B8A2E5D49D45BEA864761F",
            "6D2BE105B4F8D4C730DA271E3339D71FB81E7ABCEED0C38D626BB6A7CC43F347",
            "Tool tự động bán đồ rác",
            "icon_bandorac"
            ),
    };

    public static ToolAssemblyFile[] oldTools = new ToolAssemblyFile[]
    {
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
    };

    public static ToolAssemblyFile GetByProductID(string productID) => tools.FirstOrDefault(x => x.ProductID == productID);

    public static bool HashMatch(string hash) => tools.Any(x => x.OriginalHash == hash || x.DeobfuscatedHash == hash);

    public static bool GameAssemblyHashMatch(string hash) => tools.Any(x => x.OriginalGameAssemblyHash == hash || x.ModifiedGameAssemblyHash == hash);

    public static bool IsOldTool(string hash) => oldTools.Any(x => x.OriginalHash == hash || x.DeobfuscatedHash == hash);

    public static bool IsOldToolGameAssembly(string hash) => oldTools.Any(x => x.OriginalGameAssemblyHash == hash || x.ModifiedGameAssemblyHash == hash);

    public static string[] GetProductIDs() => tools.Select(x => x.ProductID).ToArray();
}
