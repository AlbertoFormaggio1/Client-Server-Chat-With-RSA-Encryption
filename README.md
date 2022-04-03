# Chat app with RSA Encryption

## Overview
The initial idea was to create a program capable of cyphering and decyphering some text by using the algorithm of the asymmetric key defined by RSA handshake protocol.
In order to implement this idea, I decided to create a real time chat program which cyphers and decyphers the text when sending and receiving the text of the message, respectively.
Furthermore, the program allows to create accounts (with Username and Password) which will be saved on an Access Local Database (this can be easily generalized to online databases). Every user has its own public and private keys that can be easily re-generated after the user has logged in.

## Pre-Requisites
The Microsoft Access database works only after installing:
* *Microsoft Data Access Components*: https://www.microsoft.com/en-us/download/details.aspx?id=21995
* *Microsoft Access Database Engine*: https://www.microsoft.com/en-us/download/details.aspx?id=54920

## Usage
For the program to work, 2 instances of the same program need to be open in the same local network. (it can be the same PC, but it is not necessary). One instance will be the server, the other one will be the client.
**ATTENTION!** I noticed that in some networks the program is not able to create a connection between different machines, this may be due to both your firewall and/or network security settings.

### Set up a connection

**SERVER MACHINE**
1) The IP Address you can find under the *Server* section is the address of the machine you are running the program on: do not change that.
2) Then, you will have to write any number in the Port TextBox. It is better to use high numbers for the port because they are likely not to be currently in use (Port number higher than 5000 should be fine in many cases).
3) Click START: the program will enter in an Idle phase waiting for the client to establish a connection

**CLIENT MACHINE**
1) Copy the IP address from the server machine in the *Client* section
2) Copy the Port number from the server machine
3) Click CONNECT: The connection between the two machines is now established

### Sending texts
Once a connection has been established, client and server can send text messages by using the textbox at the bottom of the window.
After sending a message, the sender will be able to see the text sent in the section on the left and the cyphered text on the right.
The receiver instead will see the cyphered received text on the right and the decyphered text which will be written in the chat on the left.

There is no need for Client and Server to take turns: anyone can send as many texts as wanted without waiting for an answer from the other user.

### Accounts and Keys
**After establishing a connection** it is possible to log in or create a new account by going to the *Account* section in the top left-hand corner.
You can now perform the desired action.
The first time you create your account both a private and a public key will be assigned to your account and will remain the same until you re-generate them.
You can re-generate the keys in the future by going to File -> Keys -> Regenerate keys.
