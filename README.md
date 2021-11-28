# Frontier Gate Boost+ Translation

## Instructions

### Unpacking the files

1. Download the source and extract it.
2. Use [7zip](https://www.7-zip.org/) or a similar software to extract all the *bin files* from the ISO's **USRDIR folder** into the project's **USRDIR folder**.
3. Open **FRONTIERGUI.exe** and click *Unpack File*, wait for it to finish. This can take up a long time to complete.

### Editing the files

1. Click *Open Json*, and select what you want to edit, edit as usual.
2. Click *Save 40PS*. This will create *40PS files* in the *USRDIR folder* and update the *txt files* in the **TXT** folder

### Repacking the files
1. Click *Repack File*, wait for it to finish, this takes up a long time too. The new *bin files* will be in the **USRDIR_NEW folder**.
2. Open the ISO with [UMDGEN](https://www.romhacking.net/utilities/1218/), replace *EBOOT.bin* with the edited one from the project's **EBOOT folder**, replace the *bin files* with the new ones from the project's **USRDIR_NEW folder** and save.
3. Test the game.

### Important 

There are 2 types of files:

- JSON/\*.json contains all the information in the \*.40PS file. *Do not modify these*.
- TXT/\*.txt contains plaintext which will be translated can be edited via **FRONTIERGUI.exe** or regular text editor *Notepad++* etc.

The Save All button can be used if many txt files have been edited.

## Tutorial video

https://youtu.be/wExN-Jm3ZEI

[![Watch the video](https://img.youtube.com/vi/wExN-Jm3ZEI/default.jpg)](https://youtu.be/wExN-Jm3ZEI)

## Instruksi

### Cara pake

1. Download source dan extract ke working directory.
2. Extract semua file *.bin ke folder USRDIR.
3. Buka FRONTIERGUI.exe dan klik Unpack File,tunggu sampai selesai, ini memakan waktu yang cukup lama.
4. Cara edit text, klik Open Json, dan pilih yang mau diedit,edit seperti biasa.
5. Klik Save 40PS.
Ini akan membuat file *.40PS di folder USRDIR/
dan mengupdate file *.txt di folder TXT/
6. Klik Repack File,tunggu sampai selesai, ini memakan waktu yang cukup lama juga.
File *.bin baru akan ada di folder USRDIR_NEW.
7. Buka iso dengan UMDGEN, ganti EBOOT.bin dengan yang telah diedit, ganti file *.bin dengan yang baru. Save.
8. Test game.

### Note

ada 2 jenis file:
- JSON/*.json mengandung semua informasi di file *.40PS,biarkan original 
- TXT/*.txt mengandung plaintext yang akan di translate
bisa diedit via FRONTIERGUI.exe atau text editor biasa Notepad++ etc

Tombol Save All bisa digunakan jika file *.txt sudah lumayan banyak yang diedit.

## Requirements

- [.NET Desktop Runtime 5+ x86](https://dotnet.microsoft.com/download/dotnet/5.0)

## Tools used

- Microsoft Visual Studio 2019+
- [Net 5.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)

## Credits

* [gil-unx](https://github.com/gil-unx): Original creator
