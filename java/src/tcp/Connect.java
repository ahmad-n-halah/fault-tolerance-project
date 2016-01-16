/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */


import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.ServerSocket;
import java.net.Socket;

/**
 *
 * @author anonymous
 */
public class Connect {
    ServerSocket serverSocket;
    Socket socket;
    InputStream is;
    OutputStream os;
    String received ;
    
    public void connect( ) throws IOException{
            serverSocket = new ServerSocket(4343, 10);
            System.out.println("wait to connect 1 ......");         
            socket = serverSocket.accept();
            System.out.println("connicting with :"+socket.getRemoteSocketAddress());       
            
}

public String recieve() throws IOException{
    // Receiving
        System.out.println("wait to received ...... ");
        is = socket.getInputStream();
        os = socket.getOutputStream();
        byte[] lenBytes = new byte[4];
        is.read(lenBytes, 0, 4);
        int len = (((lenBytes[3] & 0xff) << 24) | ((lenBytes[2] & 0xff) << 16) | ((lenBytes[1] & 0xff) << 8) | (lenBytes[0] & 0xff));
        byte[] receivedBytes = new byte[len];
        is.read(receivedBytes, 0, len);
        received = new String(receivedBytes, 0, len);
        
        return received;
}

public void send(String solution) throws IOException{
        byte[] toSendBytes = solution.getBytes();
        int toSendLen = toSendBytes.length;
        byte[] toSendLenBytes = new byte[4];
        toSendLenBytes[0] = (byte)(toSendLen & 0xff);
        toSendLenBytes[1] = (byte)((toSendLen >> 8) & 0xff);
        toSendLenBytes[2] = (byte)((toSendLen >> 16) & 0xff);
        toSendLenBytes[3] = (byte)((toSendLen >> 24) & 0xff);
        
        os.write(toSendLenBytes);
        os.write(toSendBytes);

        socket.close();
        serverSocket.close();
    
}

}
