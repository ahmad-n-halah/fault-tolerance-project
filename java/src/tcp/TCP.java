/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import java.io.IOException;

/**
 *
 * @author anonymous
 */
public class TCP {

    /**
     * @param args the command line arguments
     * @throws java.io.IOException
     */
    public static void main(String[] args) throws IOException{
        // TODO code application logic here
        String received;
        String solution;
        Connect adjecator=new Connect();
        adjecator.connect();
        received=adjecator.recieve();
        
        Solvequardatic qua =new Solvequardatic(received);
        qua.cutABC();
        solution=qua.Solve();
        adjecator.send(solution);// Sending
      
    }
    
}
