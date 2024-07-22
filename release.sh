# Publish for individual runtime
dotnet publish -c Release -o laburinthos-linux-x64 --self-contained -r linux-x64
dotnet publish -c Release -o laburinthos-windows-x64 --self-contained -r win-x64

# Install zip package if not available
if [ $(dpkg-query -W -f='${Status}' zip 2>/dev/null | grep -c "ok installed") -eq 0 ];
then
  sudo apt install zip;
fi

# Zip files for download
zip -r laburinthos-linux-x64.zip ./laburinthos-linux-x64
zip -r laburinthos-windows-x64.zip ./laburinthos-windows-x64

