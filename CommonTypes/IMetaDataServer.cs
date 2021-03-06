﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonTypes;

namespace CommonTypes
{
    public interface IMetaDataServer : IRemote
    {
        /**
         * Create
         * Creates a new file if it does not exist. 
         * Selects the dataservers for the file and assign a unique filename on each dataserver.
         * In case of success returns the metadata of that file, otherwise throws an exception.
         **/
        FileMetadata create(String clientID, string filename, int numberOfDataServers, int readQuorum, int writeQuorum);

        /**
         * Open
         * Returns the metadata content for a given file.
         * In case the file does not exist throws an exception.
         **/
        FileMetadata open(string clientID, string filename);

        /**
         * Close
         * Informs the metadataserver that the client is no longer using a given file
         **/
        void close(string clientId, string filename);

        /**
         * Delete
         * if the file is not open by any client it deletes a that file from the dataservers and returns true.
         * otherwise throws an exception.
         **/
        void delete(string clientId, string filename);

        /**
         * Update Read Metadata
         * blocks until a given file has the required number of servers to fullfill the readQuorum
         * and then returns the metadata of that file.
         **/
        FileMetadata updateReadMetadata(string clientId, string filename);

        /**
         * Update Write Metadata
         * blocks until a given file has the required number of servers to fullfill the writeQuorum
         * and then returns the metadata of that file.
         **/
        FileMetadata updateWriteMetadata(string clientId, string filename);
       
        /**
         * Fail
         * The server starts ignoring all requests from Clients and DataServers.
         **/
        void fail();

        /**
         * Recover
         * The server replys to the client and metada servers.
         **/
        void recover();

        /**
         * registDataServer
         * Saves the new dataserver
         **/
        void registDataServer(string id, string host, int port);

        void receiveHeartbeat(HeartbeatMessage heartbeat);
         
    }
}
