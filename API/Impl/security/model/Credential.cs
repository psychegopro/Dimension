﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace intrinsic.security.model {
    
    
    public class Credential: ICredential {

        public int ID { get; set; }
        public int accountID { get; set; }
        public string token { get; set; }
        public string credential { get; set; }
        public string salt { get; set; }
        public string provider { get; set; }
        public DateTimeOffset createDT { get; set; }
        public DateTimeOffset? expireDT { get; set; }
        public DateTimeOffset? renewDT { get; set; }
        public int attempts { get; set; }

        public byte enabled { get; set; }
        bool ICredential.enabled { get { return ((byte)1).Equals(this.enabled); } }

        [Timestamp]
        public byte[] rv { get; set; }

        public virtual Account Account { get; set; }

    }

    internal class CredentialMap : EntityTypeConfiguration<Credential> {

        public CredentialMap() {
            this.HasKey(k => k.ID).ToTable("Credential", "dxsecurity");

        }

    }
}
