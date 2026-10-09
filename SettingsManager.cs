using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fire_Emblem_Three_Houses_Randomizer_V2
{

    public class SettingsManager
    {
        public static void handleSettingsOnLoad(Settings settings)
        {
            if (settings.filesDirectory != null && Directory.Exists(settings.filesDirectory))
            {
                string[] files = Directory.GetFiles(settings.filesDirectory);

                foreach (string file in files)
                {
                    if (file.Contains(PERSON_FILE_NAME))
                    {
                        handlePersonData(file);
                    }
                    else if (file.Contains(CLASS_FILE_NAME)) {
                        handleClassData(file);
                    }
                    else if (file.Contains(ITEM_FILE_NAME)) {
                        handleItemData(file);
                    }
                    else if (file.Contains(CALENDAR_FILE_NAME)) {
                        handleCalendarData(file);
                    }
                    else if (file.Contains(LOBBY_FILE_NAME)) {
                        handleLobbyCommon(file);
                    } 
                    else if (file.Contains(ACT_FILE_NAME)) {
                        handleActData(file);
                    }
                    else if (file.Contains(BGM_FILE_NAME))
                    {
                        handleBGM(file);
                    }
                    else if (file.Contains(MSG_FILE_NAME))
                    {
                        settings.changeMsg = true;
                        handleMsgText(file);
                    }
                    else if (file.Contains(SCR_FILE_NAME))
                    {
                        settings.changeScr = true;
                        handleScrText(file);
                    }
                    else if (file.Contains(GWSCR_FILE_NAME))
                    {
                        settings.changeGwscr = true;
                        handleGwscrText(file);
                    }
                    else if (file.Contains(TUSCR_FILE_NAME))
                    {
                        settings.changeTuscr = true;
                        handleTuscrText(file);
                    }
                    else if (file.Contains(BTLSCR_FILE_NAME))
                    {
                        settings.changeBtlscr = true;
                        handleBtlscrText(file);
                    }
                    else if (file.Contains(ACTIVITY_FILE_NAME))
                    {
                        handleActivityData(file);
                    }
                    else if (file.Contains(GROUP_WORK_FILE_NAME))
                    {
                        handleGroupWorkData(file);
                    }
                    else if (file.Contains(PRESENT_FILE_NAME))
                    {
                        handlePresentData(file);
                    }
                    else if (file.Contains(SHOP_FILE_NAME))
                    {
                        handleShopData(file);
                    }
                    else if (file.Contains(QUEST_FILE_NAME))
                    {
                        handleLobbyQuest(file);
                    }
                    else if (file.Contains(SCENARIO_FILE_NAME))
                    {
                        handleScenarioData(file);
                    }
                    else if (file.Contains(GROWTH_DATA_FILE_NAME))
                    {
                        handleGrowthData(file);
                    }
                    else if (file.Contains(DATA1_FILE_NAME))
                    {
                        handleData1(file);
                    }
                }
            }
        }

        public static bool checkAndSave(Settings settings)
        {
            if (settings.filesDirectory != null)
            {
                if (Randomizer.personLoaded)
                {
                    writeFile(Randomizer.personFilename, Randomizer.personData);
                }
                if (Randomizer.classLoaded)
                {
                    writeFile(Randomizer.classFilename, Randomizer.classData);
                }
                if (Randomizer.itemLoaded)
                {
                    writeFile(Randomizer.itemFilename, Randomizer.itemData);
                }
                if (Randomizer.calendarLoaded)
                {
                    writeFile(Randomizer.calendarFilename, Randomizer.calendarData);
                }
                if (Randomizer.lobbyLoaded)
                {
                    writeFile(Randomizer.lobbyFilename, Randomizer.lobbyData);
                }
                if (Randomizer.actLoaded)
                {
                    writeFile(Randomizer.actFilename, Randomizer.actData);
                }
                if (Randomizer.BGMLoaded)
                {
                    writeFile(Randomizer.BGMFilename, Randomizer.BGMData);
                }
                if (Randomizer.msgLoaded && settings.changeMsg)
                {
                    writeFile(Randomizer.msgFilename, Randomizer.msgData);
                }
                if (Randomizer.scrLoaded && settings.changeScr)
                {
                    writeFile(Randomizer.scrFilename, Randomizer.scrData);
                }
                if (Randomizer.gwscrLoaded && settings.changeGwscr)
                {
                    writeFile(Randomizer.gwscrFilename, Randomizer.gwscrData);
                }
                if (Randomizer.tuscrLoaded && settings.changeTuscr)
                {
                    writeFile(Randomizer.tuscrFilename, Randomizer.tuscrData);
                }
                if (Randomizer.btlscrLoaded && settings.changeBtlscr)
                {
                    writeFile(Randomizer.btlscrFilename, Randomizer.btlscrData);
                }
                if (Randomizer.activityLoaded)
                {
                    writeFile(Randomizer.activityFilename, Randomizer.activityData);
                }
                if (Randomizer.groupWorkLoaded)
                {
                    writeFile(Randomizer.groupWorkFilename, Randomizer.groupWorkData);
                }
                if (Randomizer.presentLoaded)
                {
                    writeFile(Randomizer.presentFilename, Randomizer.presentData);
                }
                if (Randomizer.shopLoaded)
                {
                    writeFile(Randomizer.shopFilename, Randomizer.shopData);
                }
                if (Randomizer.questLoaded)
                {
                    writeFile(Randomizer.questFilename, Randomizer.questData);
                }
                if (Randomizer.scenarioLoaded)
                {
                    writeFile(Randomizer.scenarioFilename, Randomizer.scenarioData);
                }
                if (Randomizer.growthdataLoaded)
                {
                    writeFile(Randomizer.growthdataFilename, Randomizer.growthdataData);
                }
                if (Randomizer.data1Loaded)
                {
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(Randomizer.data1Filename, FileMode.Open));
                    binaryWriter.Seek((int)Randomizer.baiSectionOffset, SeekOrigin.Begin);
                    binaryWriter.Write(Randomizer.baiSectionData);
                    if (settings.changeData1Text)
                    {
                        longSeek(binaryWriter, Randomizer.textSectionOffset);
                        binaryWriter.Write(Randomizer.textSectionData);
                    }
                    binaryWriter.Close();
                    FileStream data1FileStream = File.OpenRead(Randomizer.data1Filename);

                    Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Fire_Emblem_Three_Houses_Randomizer_V2.INFO0.bin");
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    string info0 = Randomizer.data1Filename.Replace(DATA1_FILE_NAME, INFO0_FILE_NAME);
                    binaryWriter = new BinaryWriter((Stream)File.Open(info0, FileMode.Create));
                    binaryWriter.Write(buffer);
                    binaryWriter.Close();
                    stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Fire_Emblem_Three_Houses_Randomizer_V2.INFO2.bin");
                    buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    string info2 = Randomizer.data1Filename.Replace(DATA1_FILE_NAME, INFO2_FILE_NAME);
                    binaryWriter = new BinaryWriter((Stream)File.Open(info2, FileMode.Create));
                    binaryWriter.Write(buffer);
                    binaryWriter.Close();
                }

                string settingsFile = settings.filesDirectory + Path.DirectorySeparatorChar + "settings.json";
                Serializer.SaveProperties(settings, settingsFile);
                return true;
            }
            return false;
        }
        private static void longSeek(BinaryWriter bw, long offset)
        {
            bw.Seek((int)(offset % int.MaxValue), SeekOrigin.Begin);
            for (int i = 0; i < offset / int.MaxValue; i++)
                bw.Seek(int.MaxValue, SeekOrigin.Current);
        }

        private static void writeFile(string file, byte[] bytes)
        {
            BinaryWriter binaryWriter = new BinaryWriter((Stream)File.Open(file, FileMode.Create));
            binaryWriter.Write(bytes);
            binaryWriter.Close();
        }

        private static void handlePersonData(string file)
        {
            Randomizer.personDataV = readDataVHelper(file, PERSON_FILE_NAME, 139456);
            Randomizer.personFilename = file;
            Randomizer.personLoaded = true;
        }
        private static void handleClassData(string file)
        {
            Randomizer.classDataV = readDataVHelper(file, CLASS_FILE_NAME, 23812);
            Randomizer.classFilename = file;
            Randomizer.classLoaded = true;
        }
        private static void handleItemData(string file)
        {
            Randomizer.itemDataV = readDataVHelper(file, ITEM_FILE_NAME, 39000);
            Randomizer.itemFilename = file;
            Randomizer.itemLoaded = true;
        }

        private static void handleCalendarData(string file)
        {
            Randomizer.calendarDataV = readDataVHelper(file, CALENDAR_FILE_NAME, 14696);
            Randomizer.calendarFilename = file;
            Randomizer.calendarLoaded = true;
        }

        private static void handleLobbyCommon(string file)
        {
            Randomizer.lobbyDataV = readDataVHelper(file, LOBBY_FILE_NAME, 44616);
            Randomizer.lobbyFilename= file;
            Randomizer.lobbyLoaded = true;
        }

        private static void handleActData(string file)
        {
            Randomizer.actDataV = readDataVHelper(file, ACT_FILE_NAME, 172732);
            Randomizer.actFilename = file;
            Randomizer.actLoaded = true;
        }

        private static void handleBGM(string file)
        {
            Randomizer.BGMDataV = readDataVHelper(file, BGM_FILE_NAME, 398136704);
            Randomizer.BGMFilename = file;
            Randomizer.BGMLoaded = true;
        }

        private static void handleActivityData(string file)
        {
            Randomizer.activityDataV = readDataVHelper(file, ACTIVITY_FILE_NAME, 16504);
            Randomizer.activityFilename = file;
            Randomizer.activityLoaded = true;
        }

        private static void handleGroupWorkData(string file)
        {
            Randomizer.groupWorkDataV = readDataVHelper(file, GROUP_WORK_FILE_NAME, 4432);
            Randomizer.groupWorkFilename = file;
            Randomizer.groupWorkLoaded = true;
        }
        private static void handlePresentData(string file)
        {
            Randomizer.presentDataV = readDataVHelper(file, PRESENT_FILE_NAME, 6180);
            Randomizer.presentFilename = file;
            Randomizer.presentLoaded = true;
        }
        private static void handleShopData(string file)
        {
            Randomizer.shopDataV = readDataVHelper(file, SHOP_FILE_NAME, 18676);
            Randomizer.shopFilename = file;
            Randomizer.shopLoaded = true;
        }

        private static void handleLobbyQuest(string file)
        {
            Randomizer.questDataV = readDataVHelper(file, QUEST_FILE_NAME, 8672);
            Randomizer.questFilename = file;
            Randomizer.questLoaded = true;
        }
        private static void handleScenarioData(string file)
        {
            Randomizer.scenarioDataV = readDataVHelper(file, SCENARIO_FILE_NAME, 4784);
            Randomizer.scenarioFilename = file;
            Randomizer.scenarioLoaded = true;
        }
        private static void handleGrowthData(string file)
        {
            Randomizer.growthdataDataV = readDataVHelper(file, GROWTH_DATA_FILE_NAME, 1404);
            Randomizer.growthdataFilename = file;
            Randomizer.growthdataLoaded = true;
        }

        private static void handleData1(string file)
        {
            Randomizer.data1Filename = file;
            FileStream data1FileStream = File.OpenRead(Randomizer.data1Filename);
            Randomizer.baiSectionDataV = new byte[Randomizer.baiSectionLength];
            data1FileStream.Seek(Randomizer.baiSectionOffset, SeekOrigin.Begin);
            data1FileStream.Read(Randomizer.baiSectionDataV, 0, Randomizer.baiSectionLength);
            Randomizer.textSectionDataV = new byte[Randomizer.textSectionLength];
            data1FileStream.Seek(Randomizer.textSectionOffset, SeekOrigin.Begin);
            data1FileStream.Read(Randomizer.textSectionDataV, 0, Randomizer.textSectionLength);
            Randomizer.data1Loaded = true;
        }
        private static void handleMsgText(string file)
        {
            Randomizer.msgDataV = readDataVHelper(file, MSG_FILE_NAME, 9586308);
            Randomizer.msgFilename = file;
            Randomizer.msgLoaded = true;
        }
        private static void handleScrText(string file)
        {
            Randomizer.scrDataV = readDataVHelper(file, SCR_FILE_NAME, 6736028);
            Randomizer.scrFilename = file;
            Randomizer.scrLoaded = true;
        }
        private static void handleGwscrText(string file)
        {
            Randomizer.gwscrDataV = readDataVHelper(file, GWSCR_FILE_NAME, 941488);
            Randomizer.gwscrFilename = file;
            Randomizer.gwscrLoaded = true;
        }
        private static void handleTuscrText(string file)
        {
            Randomizer.tuscrDataV = readDataVHelper(file, TUSCR_FILE_NAME, 787776);
            Randomizer.tuscrFilename = file;
            Randomizer.tuscrLoaded = true;
        }
        private static void handleBtlscrText(string file)
        {
            Randomizer.btlscrDataV = readDataVHelper(file, BTLSCR_FILE_NAME, 807848);
            Randomizer.btlscrFilename = file;
            Randomizer.btlscrLoaded = true;
        }

        private static byte[] readDataVHelper(string file, string fileName, long expectedLength)
        {
            FileStream fileStream = File.OpenRead(Randomizer.personFilename);
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int)fileStream.Length);
            if (bytes.Length == expectedLength)
            {
                fileStream.Close();
            }
            else
            {
                int num = (int)MessageBox.Show("Your " + fileName + " loaded fine, but the size doesn't seem right. You can continue with randomizing the file, but it may not work as intended. Please ensure you have the right file!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                fileStream.Close();
            }
            return bytes;
        }

        public static string PERSON_FILE_NAME = "fixed_persondata.bin";
        public static string CLASS_FILE_NAME = "fixed_classdata.bin";
        public static string ITEM_FILE_NAME = "fixed_data.bin";
        public static string CALENDAR_FILE_NAME = "fixed_calendardata.bin";
        public static string LOBBY_FILE_NAME = "fixed_lobby_common.bin";
        public static string ACT_FILE_NAME = "fixed_act_data.bin";
        public static string BGM_FILE_NAME = "BGM.ktsl2stbin";
        public static string MSG_FILE_NAME = "msgdata.bin";
        public static string SCR_FILE_NAME = "scrdata.bin";
        public static string GWSCR_FILE_NAME = "gwscrdata.bin";
        public static string TUSCR_FILE_NAME = "tuscrdata.bin";
        public static string BTLSCR_FILE_NAME = "btlscrdata.bin";
        public static string ACTIVITY_FILE_NAME = "fixed_lobby_activity.bin";
        public static string GROUP_WORK_FILE_NAME = "fixed_groupworkdata.bin";
        public static string PRESENT_FILE_NAME = "fixed_presentdata.bin";
        public static string SHOP_FILE_NAME = "fixed_shopdata.bin";
        public static string QUEST_FILE_NAME = "fixed_lobby_quest.bin";
        public static string SCENARIO_FILE_NAME = "fixed_scenario.bin";
        public static string GROWTH_DATA_FILE_NAME = "fixed_growthdata.bin";
        public static string DATA1_FILE_NAME = "DATA1.bin";
        public static string INFO0_FILE_NAME = "INFO0.bin";
        public static string INFO2_FILE_NAME = "INFO2.bin";

    }
}
