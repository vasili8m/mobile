﻿using System;

namespace Bit.iOS.Core.Models
{
    public class AppExtensionContext
    {
        private string _uriString;

        public Uri Uri
        {
            get
            {
                Uri uri;
                if(string.IsNullOrWhiteSpace(UrlString) || !Uri.TryCreate(UrlString, UriKind.Absolute, out uri))
                {
                    return null;
                }

                return uri;
            }
        }
        public string UrlString
        {
            get
            {
                return _uriString;
            }
            set
            {
                _uriString = value;
                if(string.IsNullOrWhiteSpace(_uriString))
                {
                    return;
                }

                if(!_uriString.StartsWith(App.Constants.iOSAppProtocol) && _uriString.Contains("."))
                {
                    if(!_uriString.Contains("://") && !_uriString.Contains(" "))
                    {
                        _uriString = string.Concat("http://", _uriString);
                    }
                }

                if(!_uriString.StartsWith("http") && !_uriString.StartsWith(App.Constants.iOSAppProtocol))
                {
                    _uriString = string.Concat(App.Constants.iOSAppProtocol, _uriString);
                }
            }
        }
        public PasswordGenerationOptions PasswordOptions { get; set; }
    }
}