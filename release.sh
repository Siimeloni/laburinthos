# Publish for individual runtime
dotnet publish -c Release -o PublishLinux-x64 --self-contained -r linux-x64
dotnet publish -c Release -o PublishWindows-x64 --self-contained -r win-x64

# Install zip package if not available
if [ $(dpkg-query -W -f='${Status}' zip 2>/dev/null | grep -c "ok installed") -eq 0 ];
then
  sudo apt install zip;
fi

# Zip files for download
zip -r linux-x64.zip ./PublishLinux-x64
zip -r windows-x64.zip ./PublishWindows-x64

