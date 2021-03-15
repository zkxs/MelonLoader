﻿using System;

namespace MelonLoader.AssemblyGenerator
{
    internal static class RemoteAPI
    {
        internal static InfoStruct LAST_RESPONSE = new InfoStruct();
        internal static bool ShouldMakeContact = true;
        private static event Action HostContacts;

        static RemoteAPI()
        {
            HostContacts += RemoteAPIHosts.Melon.Contact;
            HostContacts += RemoteAPIHosts.Melon1.Contact;
            HostContacts += RemoteAPIHosts.Melon2.Contact;
            HostContacts += RemoteAPIHosts.Ruby.Contact;
            HostContacts += RemoteAPIHosts.Samboy.Contact;
        }

        internal static void Contact()
        {
            Logger.Msg("Contacting RemoteAPI...");
            HostContacts();
            DebugPrintResponse();
        }

        private static void DebugPrintResponse()
        {
            Logger.Msg($"ForceDumperVersion = {(string.IsNullOrEmpty(LAST_RESPONSE.ForceDumperVersion) ? "null" : LAST_RESPONSE.ForceDumperVersion)}");
            Logger.Msg($"ForceUnhollowerVersion = {(string.IsNullOrEmpty(LAST_RESPONSE.ForceUnhollowerVersion) ? "null" : LAST_RESPONSE.ForceUnhollowerVersion)}");
            Logger.Msg($"ObfuscationRegex = {(string.IsNullOrEmpty(LAST_RESPONSE.ObfuscationRegex) ? "null" : LAST_RESPONSE.ObfuscationRegex)}");
            Logger.Msg($"MappingURL = {(string.IsNullOrEmpty(LAST_RESPONSE.MappingURL) ? "null" : LAST_RESPONSE.MappingURL)}");
            Logger.Msg($"MappingFileSHA512 = {(string.IsNullOrEmpty(LAST_RESPONSE.MappingFileSHA512) ? "null" : LAST_RESPONSE.MappingFileSHA512)}");
        }

        internal class InfoStruct
        {
            public string ForceDumperVersion = null;
            public string ForceUnhollowerVersion = null;
            public string ObfuscationRegex = null;
            public string MappingURL = null;
            public string MappingFileSHA512 = null;
        }
    }
}