var plugin = {
                 ConnectWallet: function () {
                   window.dispatchReactUnityEvent("OnConnectWallet");
                 },
             }

mergeInto(LibraryManager.library, plugin);
