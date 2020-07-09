using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.IO;
using MongoDB.Driver;
using MongoDB.Bson;
using SharpCompress.Common;
using MongoDB.Driver.Core.Clusters.ServerSelectors;
using System.Security.Cryptography;
using System.Security.Permissions;

namespace RSACoreLib
{
    public class RSACore
    {
        // new definitions
        private static RSACore oRSACore;
        private MongoClient _MongoClient;
        public Boolean IsConnected { get; set; }
        public IMongoDatabase dbRSADupCheck { get; set; }
        public IMongoCollection<BsonDocument> RSAVolumes;
        public IMongoCollection<BsonDocument> RSAHashes;

        public Boolean HasConfigured { get; set; }
        public String BaseFolder { get; set; }
        public String StructuredFolder { get; set; }
        public String DuplicatedFolder { get; set; }
        public String DbAddress { get; set; }
        public String DbPort { get; set; }

        public static RSACore GetInstance()
        {
            if (oRSACore == null)
            {
                // Cria instancia em memoria se ainda não existe oooo
                oRSACore = new RSACore();
                //oRSACore.DbConnParam = "";
            }
            return oRSACore;
        }
        public RSACore()
        {
            // Dicionario de dados
            // volumes
            // {
            //      serial,
            //      type,
            //      insertDate,
            //      lastScanningDate
            // }
            //
            //
            // hashes
            // {
            //      hash,
            //      paths:
            //      [
            //          {
            //              volume,
            //              filename,
            //              insertDate,
            //              status
            //          }
            //      ]
            //      },
            //      classification,
            //      friendlyname,
            //      tags
            //      {
            //
            //      }
            //      insertDate,
            // }
        }
        public Boolean Connect()
        {
            //database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(1000);
            if (_MongoClient == null)
            {
                _MongoClient = new MongoClient("mongodb://" + oRSACore.DbAddress + ":" + oRSACore.DbPort);
            }
            try
            {
                dbRSADupCheck = _MongoClient.GetDatabase("rsadupcheck", null);
                if (!dbRSADupCheck.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(1000))
                {
                    IsConnected = false;
                    return false;
                }
            }
            catch(Exception oErr)
            {
                return false;
            }

            RSAVolumes = dbRSADupCheck.GetCollection<BsonDocument>("volumes", null);
            RSAHashes = dbRSADupCheck.GetCollection<BsonDocument>("hashes", null);
            // Associa as collections

            IsConnected = true;
            return true;           
        }
        public String CalcularHash(String pArquivo)
        {
            System.Security.Cryptography.SHA256 oSHA256 = System.Security.Cryptography.SHA256.Create();
            String sHashSolved = "";
            System.IO.FileStream oStream;
            try
            {
                oStream = System.IO.File.OpenRead(pArquivo);
                sHashSolved = BitConverter.ToString(oSHA256.ComputeHash(oStream)).Replace("-", "").ToUpper();
            }
            catch (Exception oExc)
            {
                throw oExc;
            }
            return sHashSolved;
        }
        public Boolean HasSubFolders(String pFolder)
        {
            //List<String> _AllowedFolder = new List<String>();
            //_AllowedFolder.Add(pFolder);
            try
            {
                String[] _Directories = Directory.GetDirectories(pFolder);
                if (_Directories.Length > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch ( Exception oException)
            {
                throw new Exception("Falha");
            }
        }
        public String[] GetSubFolders(String[] pFolders)
        {
            List<String> _AllowedFolder = new List<String>();
            foreach (String pFolder in pFolders)
            {
                try
                {
                    if (HasSubFolders(pFolder))
                    {
                        String[] _subDirs = GetSubFolders(Directory.GetDirectories(pFolder, "*.*", SearchOption.TopDirectoryOnly));
                        _AllowedFolder.Add(pFolder);
                        foreach(String subDir in _subDirs)
                        {
                            _AllowedFolder.Add(subDir);
                        }
                    }
                    else
                    {
                        _AllowedFolder.Add(pFolder);
                        foreach (String pSubFolder in Directory.GetDirectories(pFolder, "*.*", SearchOption.TopDirectoryOnly))
                        {
                            _AllowedFolder.Add(pSubFolder);
                        }
                    }
                }
                catch(Exception oException)
                {

                }
            }
            return _AllowedFolder.ToArray();
        }
    }
    public class RSAVolume
    {
        public enum Status
        {
            SerialNotInformed,
            SerialNotFound,
            SerialFound
        }
        public String serial { get; set; }
        public String type { get; set; }
        public DateTime insertDate { get; set; }
        public DateTime lastScanningDate { get; set; }
        public Status GetVolume()
        {
            RSAVolume _this = null;
            RSAData oData = new RSAData();
            //_this = oData.GetVolumeBySerial(this.serial);
            if (_this != null)
            {
                serial = _this.serial;
                type = _this.type;
                insertDate = _this.insertDate;
                lastScanningDate = _this.lastScanningDate;
            }
            else
            {
                return Status.SerialNotFound;
            }
            return Status.SerialFound;
        }
        public void AddVolume()
        {
            RSAData oData = new RSAData();
            oData.AddVolume(this.ToBsonDocument().ToString());
        }
    }
    public class RSAPath
    {
        public enum Status
        {
            New,
            Processed,
            ForDeletion,
            Killed
        }
        public String volume { get; set; }
        public String filename { get; set; }
        public DateTime insertDate { get; set; }
        public Status status { get; set; }
    }
    public class RSAHash
    {
        public enum Status
        {
            HashNotInformed,
            HashNotFound,
            HashFound,
            HashUpdated
        }
        public String hash;
        public List<RSAPath> paths { get; set; }
        public String classification;
        public String friendlyname;
        public String tags;
        public DateTime insertDate;
        public Status GetRSAHash()
        {
            RSAHash _this;
            RSAData oData = new RSAData();
            _this = oData.GetRSAHash(this.hash);
            if ( _this != null)
            {
                classification = _this.classification;
                friendlyname = _this.friendlyname;
                tags = _this.tags;
                insertDate = _this.insertDate;
                paths = _this.paths;
                return RSAHash.Status.HashFound;
            }
            return RSAHash.Status.HashNotFound;
        }

        public Status UpdateMetadata()
        {
            RSAData oData = new RSAData();
            return oData.UpdateMetadata(this.hash,
                                        this.classification,
                                        this.tags);
        }

        public void AddPath(RSAPath pRSAPath)
        {
            RSAData oData = new RSAData();
            oData.AddPath(this.hash, pRSAPath);
        }
        public void AddHash()
        {
            RSAData oData = new RSAData();
            //oData.AddHash(this.ToBsonDocument().ToString());
            oData.AddHash(this);
            return;
        }
        public List<RSAHashAggregate> GetHashesForOrganizer()
        {
            RSAData oData = new RSAData();
            return oData.GetHashesForOrganizer();
        }

        public Status UpdatePathStatus()
        {
            RSAData oData = new RSAData();
            return oData.UpdatePathStatus(this.hash,
                                          this.paths[0].filename,
                                          this.paths[0].status);
        }
        // hashes
        // {
        //      hash,
        //      paths:
        //      [
        //          {
        //              volume,
        //              filename,
        //              insertDate,
        //              status
        //          }
        //      ]
        //      },
        //      classification,
        //      friendlyname,
        //      tags
        //      {
        //
        //      }
        //      insertDate,
        // }
    }
    public class RSAHashAggregate
    {
        public String _id { get; set; }
        public String hash_id { get; set; }
        public Int32 contagem { get; set; }
    }
    public class RSAData
    {
        private RSACore oRSACore;
        private MongoClient _MongoClient;
        public IMongoDatabase dbRSADupCheck { get; set; }
        public IMongoCollection<BsonDocument> RSAVolumes;
        public IMongoCollection<BsonDocument> RSAHashes;
        public RSAData()
        {
            oRSACore = RSACore.GetInstance();
            Connect();
        }
        private Boolean Connect()
        {
            //database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(1000);
            if (_MongoClient == null)
            {
                _MongoClient = new MongoClient("mongodb://" + oRSACore.DbAddress + ":" + oRSACore.DbPort);
            }
            try
            {
                dbRSADupCheck = _MongoClient.GetDatabase("rsadupcheck", null);
                if (!dbRSADupCheck.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(1000))
                {
                    return false;
                }
            }
            catch (Exception oErr)
            {
                return false;
            }
            return true;
        }
        public RSAVolume GetVolumeBySerial(String pSerial)
        {
            RSAVolume _RSAVolume;
            try
            {
                var mgReturn = dbRSADupCheck.GetCollection<BsonDocument>("volumes").Find(new BsonDocument("serial", pSerial)).Single<BsonDocument>();
                _RSAVolume = new RSAVolume();
                _RSAVolume.serial = mgReturn.GetValue("serial").ToString();
                _RSAVolume.type = mgReturn.GetValue("type").ToString();
                _RSAVolume.insertDate = Convert.ToDateTime(mgReturn.GetValue("insertDate").ToString());
                if (mgReturn.GetValue("lastScanningDate").ToString() != "")
                {
                    _RSAVolume.lastScanningDate = Convert.ToDateTime(mgReturn.GetValue("lastScanningDate").ToString());
                }
                else
                {
                    _RSAVolume.lastScanningDate = new DateTime();
                }
            }
            catch (Exception oErr)
            {
                _RSAVolume = null;
            }
            return _RSAVolume;
        }
        public void AddVolume(String pVolume)
        {
            dbRSADupCheck.GetCollection<BsonDocument>("volumes").InsertOne(BsonDocument.Parse(pVolume));
        }
        public RSAHash GetRSAHash(String pHashID)
        {
            RSAHash _RSAHash;
            List<RSAPath> _RSAPaths = new List<RSAPath>(); ;
            RSAPath _RSAPath;
            try
            {
                var mgReturn = dbRSADupCheck.GetCollection<BsonDocument>("hashes").Find(new BsonDocument("hash", pHashID)).Single<BsonDocument>();
                _RSAHash = new RSAHash();
                //_RSAPaths = new RSAPath[]();
                _RSAHash.hash = mgReturn.GetValue("hash").ToString();
                _RSAHash.classification = mgReturn.GetValue("classification").ToString();
                _RSAHash.friendlyname = mgReturn.GetValue("friendlyname").ToString();
                _RSAHash.insertDate = Convert.ToDateTime(mgReturn.GetValue("insertDate").ToString());
                _RSAHash.tags = mgReturn.GetValue("tags").IsBsonNull? "" : mgReturn.GetValue("tags").ToString();
                //_RSAPaths = BsonDocument.Parse(mgReturn.GetValue("insertdate").ToString()).ToList()
                foreach (var oItem in mgReturn.GetValue("paths").AsBsonArray)
                {
                    _RSAPath = new RSAPath();
                    _RSAPath.filename = oItem["filename"].ToString();
                    _RSAPath.volume = oItem["volume"].ToString();
                    _RSAPath.insertDate = Convert.ToDateTime(oItem["insertDate"].ToString());
                    _RSAPath.status = (RSAPath.Status) Convert.ToInt32(oItem["status"]);
                    _RSAPaths.Add(_RSAPath);

                    //_RSAPaths.Add(oItem.);
                }
                _RSAHash.paths = _RSAPaths;
            }
            catch (Exception oErr)
            {
                _RSAHash = null;
            }
            return _RSAHash;
        }
        internal void AddPath(String pHash, RSAPath pRSAPath)
        {
            BsonDocument _filter = new BsonDocument();
            _filter.Add("hash", pHash.ToString());
            var update = Builders<BsonDocument>.Update.AddToSet("paths", pRSAPath);
            dbRSADupCheck.GetCollection<BsonDocument>("hashes").UpdateOne(_filter, update);
        }
        internal void AddHash(RSAHash pRSAHash)
        {
            dbRSADupCheck.GetCollection<BsonDocument>("hashes").InsertOne(BsonDocument.Parse(pRSAHash.ToBsonDocument().ToString()));
        }
        internal List<RSAHashAggregate> GetHashesForOrganizer()
        {
            List<RSAHashAggregate> _aggregate = new List<RSAHashAggregate>();
            try
            {
                var filtro = dbRSADupCheck.GetCollection<BsonDocument>("hashes").Aggregate()
                                          .Project(new BsonDocument{
                                                                 {"_id", "$hash"},
                                                                 new BsonDocument{{"hash_id", "$_id" }},
                                                                 {"contagem", new BsonDocument("$size", "$paths")}
                                                                   })
                                          .Sort(new BsonDocument{
                                                               {"contagem", -1}
                                                                })
                                          .Match(new BsonDocument{
                                                                { "contagem", new BsonDocument("$gt", 0)}
                                                                 });
                var results = filtro.ToList();
                foreach(var oItem in results.ToList())
                {
                    RSAHashAggregate _itemAggregate = new RSAHashAggregate();
                    _itemAggregate._id = oItem.GetValue("_id").ToString();
                    _itemAggregate.hash_id = oItem.GetValue("hash_id").ToString();
                    _itemAggregate.contagem = Convert.ToInt32(oItem.GetValue("contagem"));
                    _aggregate.Add(_itemAggregate);
                }
            }
            catch (Exception oErr)
            {
                _aggregate = null;
            }
            return _aggregate;
        }

        internal RSAHash.Status UpdateMetadata(String pHash, String pClassification, String pTags)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("hash", pHash);
            var up = Builders<BsonDocument>.Update.Set("classification", pClassification)
                                                  .Set("tags", pTags);
            try
            {
                dbRSADupCheck.GetCollection<BsonDocument>("hashes").UpdateOne(filter, up);
            }
            catch (Exception oErr)
            {
                return RSAHash.Status.HashNotFound;
            }
            return RSAHash.Status.HashUpdated;
        }

        internal RSAHash.Status UpdatePathStatus(String pHash, String pFilename, RSAPath.Status pStatus)
        {
            var upOption = new UpdateOptions();
            var filter = Builders<BsonDocument>.Filter.Eq("hash", pHash);
            upOption.ArrayFilters = new List<ArrayFilterDefinition> {
                new BsonDocumentArrayFilterDefinition<BsonDocument>(
                new BsonDocument("element.filename",
                                 pFilename)) };
            var up = Builders<BsonDocument>.Update.Set("paths.$[element].status", pStatus);
            try
            {
                dbRSADupCheck.GetCollection<BsonDocument>("hashes").UpdateOne(filter, up, upOption);
                return RSAHash.Status.HashUpdated;
            }
            catch (Exception oErr)
            {
                return RSAHash.Status.HashNotFound;
            }
        }
    }
}
