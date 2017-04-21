# SafePad
SafePad : Encrypted Text Editor

## What is SafePad

SafePad is a simple FREE text editor that lets you encrypt your documents using the industry standard FIPS Compliant AES encryption algorithm (Advanced Encryption Standard). To protect your document you can provide 2 passwords (the 2nd password is optional). Passwords have always been a problem when it comes to security as users tend to pick a password that is easy for them to remember. This also means that the password is most likely easy to crack. By using 2 passwords and performing multiple iterations of encryption, it makes it much harder to crack the passwords. If someone manages to crack password 1, all they will get back is encrypted text, so it would be very hard to them to know they have cracked that password.

Picking strong yet easy to remember passwords is essential when protecting your files. If your passwords are easy to guess or can be cracked by a brute force search then you are leaving your data open to being stolen. Here is a good article over at wolfram.org with some good advice on picking strong passwords.

SafePad is ideal for protecting the following types of information:

**Passwords**: to other sites: When you have to create passwords for different sites and systems, people tend to stick to the same passwords as they are easy to remember. It is a better idea to create unique and strong passwords and then store them in SafePad. You only then need to remember the 2 SafePad passwords. SafePad even has a built in password generator where you can create secure passwords and insert them straight into your document.

**Banking and Card Details**: Banking log on details and card information is generally quite hard to remember. You can safely store them in SafePad protected by your 2 master passwords instead of having them written down on paper somewhere.

**Any Other Secrets**: SafePad is a text editor so you can write anything you like in your document. This is great for storing your ideas and plans that you want to keep secret. Theft of commercial secrets is big business, so don’t open yourself up to the risk.


## Features

The primary goal of SafePad is to offer a way to protect your documents from prying eyes. SafePad offers the following features:

1. **Encrypt your documents** using AES encryption based on the strength of 2 passwords.
2. **Password entry form** has a password strength indicator.
3. **Rich text editor** with familiar word processing formatting controls and font selection.
4. **Low contrast themes** to make the text harder to read on the screen if people are looking over your shoulder.
5. **White Out Theme** that turns all the text white when you press CTRL + 2. This is in-case you spot someone looking at your screen and you want to quickly make the text invisible.
7. **Quickly Minimise** the application by pressing the Escape key if someone is looking at your screen.
8. **Drag and drop** files from explorer into your document so they get encrypted too.
9. **On Screen Keyboard** that allows you to enter the password with a mouse or touch screen. This was requested by people who were worried about key loggers on their computer.
10. **Browse** to a link when a URL is highlighted in the document. 

## Why SafePad

With the revelations of government snooping by the NSA and GCHQ hitting the press over the last year thanks to the leaks from Edward Snowden, it has become obvious that if you care about your privacy in the digital world, then you need to take steps to protect your data. I developed SafePad to be an easy to use tool to help ordinary users protect their secrets. SafePad is completely FREE of charge. I don’t believe you should pay for privacy and I don’t think companies should be charging for encryption products like this aimed at normal everyday computer users.

SafePad is also open source, which means anyone can look at the source code if they choose too. Offering full transparency is the best way to help guard your privacy as the source code can be subject to peer review. The security of SafePad is based purely on the strength of the passwords that you chose to use. SafePad uses encryption algorithms that are deemed as standards (AES) and have already been subject to analysis by experts in their field.

When I developed the first version of SafePad I had no idea if anyone would want to use it. I put it up on CodePlex (Microsoft’s Open Source sharing site) so that anyone could find it. So far over 1000 people at the time of writing have downloaded the application, and many users have offered suggestions. Version 1.3 addresses many of the suggestions from users. The majority of the new features are around usability.

## Change Log in SafePad 1.3

* Added check box to the password entry screen to allow you to cache a password for the currently loaded session.
* Password generator.
* Fixed Issue where Document Saved Flag incorrectly getting set.
* Fix bug where closing the app when minimised causes the application to restore minimised, which makes it hard to get the window back. If the app is minimised when closed, it will save the state as maximised.

## Change Log in SafePad 1.2

* Use BCrypt as the internal password hash and increase the file format number to 1.1. Old files of version 1.0 are backwards compatible. They will get saved automatically to version 1.1.
* Made password 2 optional. I still recommend using 2 passwords, but you don’t have too.
* Enter on first field on passwords entry dialog box moves focus to second field. Enter on second field is the same as clicking the OK button.
* When doing a normal save over the top of a file, prompt the user if they want to overwrite the file.
* Implement panic key to quickly minimize the application. This is bound to the ESC key.
* Use AesCryptoServiceProvider instead of ManagedAES as it is FIPS compliant.
* Have the option to disable DetectURLS.
* When entering a password, implement an on-screen keyboard so that the user can avoid typing the password on the keyboard. This is to guard against key sniffers. This is a user request.
* Change 1.1 file format so that it generates a new salt for each save.
* Changed the PBKDF function (Rfc2898DeriveBytes) to perform 40,000 rounds when creating the encryption key.
* Add context menu to the rich text view to include all the standard editing features.
* Implement an application properties dialog to give more customisation to the user.
* Implement screen white hot key out to change th text to the same color as the background.
* Recent files list on the file menu.
* Whilst getting feedback on the application from security professionals, the common consensus seems to be that using Cascaded iteration of AES offers no additional security over doing it once. I have changed the new file format to only run AES once, but the 2 passwords are combined together first into a longer password.
* Implement Find and Replace.
* Add the word wrap option to the application settings.
* Add Help link to the Help Menu. This will load up a manual page on http://www.stephenhaunts.com
* Add Cut / Copy / Paste to context menu.
* If link selected in document, add a ‘Browse to Link’ option to the context menu.
* Export file to RTF.

## Change Log in SafePad 1.1

* The following changes have been made to SafePad since version 1.0.
* Added loader factory to support older versions of the file format to make it backwards compatible. If you save a file in an older file format, it will be saved in the latest format.
* Add a font selector and font size selector to the main tool-bar.
* Password entry dialog box now accepts Return key on each text box.
* Make the save button/menu item act more like a normal Save Button. Also added a “Save As” menu item that will always prompt for a password and file-name.
* If you try to exit with unsaved changes, prompt to save.
* Add password strength meter to password input box. This uses rules like using numbers, mixed case, punctuation symbols and length as indicators. The meter will also do a white-list check against common password along with letter substituted versions.
* Add Status bar to the bottom of the window to display common prompts like new document, loaded and saved etc.
* Save window state to XML settings file.
* Add themes menu. This allows you to select a low contrast (dark or light) theme. This is to make seeing text difficult for anyone overlooking your screen. You can also pick a custom background and foreground colour.
* Added a new about dialog box.
* Remove Install Shield project. I will distribute as a zip file for the moment until I build a WIX installer.
* Allow the dragging and dropping of files into the document. The whole document is compressed before it is encrypted.
* Add Zoom factor menu to the status bar.
* Fixed a crash bug where selecting text that contains multiple fonts would cause the application to crash.

