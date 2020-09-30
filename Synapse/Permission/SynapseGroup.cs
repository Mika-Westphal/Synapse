﻿using Synapse.Api;
using Synapse.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using YamlDotNet.Serialization;

namespace Synapse.Permission
{
    public class SynapseGroup : IConfigSection
    {
     
        public string Password = "NONE";

        public bool Default = false;

        public bool Northwood = false;

        public bool RemoteAdmin = false;

        public string Badge = "NONE";

        public string Color = "NONE";

        public bool Cover = false;

        public bool Hidden = false;

        public byte KickPower = 0;

        public byte RequiredKickPower = 1;

        public List<string> Permissions = new List<string> { };

        public List<string> Members = new List<string> { };

        /*public bool HasPermission(string Permission)
        {

        }*/

        public bool HasVanillaPermission(PlayerPermissions permission) => Permissions.Any(x => x.ToLower() == $"{VanillaPrefix}.{permission}".ToLower());

        public ulong GetVanillaPermissionValue()
        {
            if (Permissions.Any(x => x == "*" || x == ".*" || x == $"{VanillaPrefix}.*"))
                return FullVanillaPerms();

            var vanillaperms = Permissions.Where(x => x.Split('.')[0].ToLower() == VanillaPrefix);

            List<PlayerPermissions> perms = new List<PlayerPermissions>();
            foreach(var perm in vanillaperms)
                if (Enum.TryParse<PlayerPermissions>(perm.Split('.')[1], out var permenum))
                    perms.Add(permenum);

            ulong Permission = 0;
            foreach (var perm in perms)
                Permission += (ulong)perm;

            return Permission;
        }

        private ulong FullVanillaPerms()
        {
            ulong fullperm = 0;
            foreach (var perm in (PlayerPermissions[])Enum.GetValues(typeof(PlayerPermissions)))
                fullperm += (ulong)perm;

            return fullperm;
        }

        private const string VanillaPrefix = "vanilla";
    }
}
