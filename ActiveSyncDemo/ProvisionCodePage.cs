﻿using OmaSharp.WBXML;

namespace ActiveSyncDemo
{
    internal class ProvisionCodePage : TagCodePage
    {
        public ProvisionCodePage()
        {
            AddToken(0x05, "Provision");
            AddToken(0x06, "Policies");
            AddToken(0x07, "Policy");
            AddToken(0x08, "PolicyType");
            AddToken(0x09, "PolicyKey");
            AddToken(0x0A, "Data");
            AddToken(0x0B, "Status");
            AddToken(0x0C, "RemoteWipe");
            AddToken(0x0D, "EASProvisionDoc");
            AddToken(0x0E, "DevicePasswordEnabled");
            AddToken(0x0F, "AlphanumericDevicePasswordRequired");
            AddToken(0x10, "DeviceEncryptionEnabled");
                //What to do with RequireStorageCardEncryption which has the same token?
            AddToken(0x11, "PasswordRecoveryEnabled");
            AddToken(0x12, "DocumentBrowseEnabled");
            AddToken(0x13, "AttachmentsEnabled");
            AddToken(0x14, "MinDevicePasswordLength");
            AddToken(0x15, "MaxInactivityTimeDeviceLock");
            AddToken(0x16, "MaxDevicePasswordFailedAttempts");
            AddToken(0x17, "MaxAttachmentSize");
            AddToken(0x18, "AllowSimpleDevicePassword");
            AddToken(0x19, "DevicePasswordExpiration");
            AddToken(0x1A, "DevicePasswordHistory");
            AddToken(0x1B, "AllowStorageCard");
            AddToken(0x1C, "AllowCamera");
            AddToken(0x1D, "RequireDeviceEncryption");
            AddToken(0x1E, "AllowUnsignedApplications");
            AddToken(0x1F, "AllowUnsignedInstallationPackages");
            AddToken(0x20, "MinDevicePasswordComplexCharacters");
            AddToken(0x21, "AllowWiFi");
            AddToken(0x22, "AllowTextMessaging");
            AddToken(0x23, "AllowPOPIMAPEmail");
            AddToken(0x24, "AllowBluetooth");
            AddToken(0x25, "AllowIrDA");
            AddToken(0x26, "RequireManualSyncWhenRoaming");
            AddToken(0x27, "AllowDesktopSync");
            AddToken(0x28, "MaxCalendarAgeFilter");
            AddToken(0x29, "AllowHTMLEmail");
            AddToken(0x2A, "MaxEmailAgeFilter");
            AddToken(0x2B, "MaxEmailBodyTruncationSize");
            AddToken(0x2C, "MaxEmailHTMLBodyTruncationSize");
            AddToken(0x2D, "RequireSignedSMIMEMessages");
            AddToken(0x2E, "RequireEncryptedSMIMEMessages");
            AddToken(0x2F, "RequireSignedSMIMEAlgorithm");
            AddToken(0x30, "RequireEncryptionSMIMEAlgorithm");
            AddToken(0x31, "AllowSMIMEEncryptionAlgorithmNegotiation");
            AddToken(0x32, "AllowSMIMESoftCerts");
            AddToken(0x33, "AllowBrowser");
            AddToken(0x34, "AllowConsumerEmail");
            AddToken(0x35, "AllowRemoteDesktop");
            AddToken(0x36, "AllowInternetSharing");
            AddToken(0x37, "UnapprovedInROMApplicationList");
            AddToken(0x38, "ApplicationName");
            AddToken(0x39, "ApprovedApplicationList");
            AddToken(0x3A, "Hash");
        }
    }
}