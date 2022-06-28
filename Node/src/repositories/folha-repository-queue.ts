import { Connection, Channel, connect } from "amqplib";

var conn: Connection;
var channel: Channel;

export class FolhaRepositoryQueue {
    constructor(private uri: string) {      
    }

    async start(){
        conn = await connect(this.uri);
        channel = await conn.createChannel();

        setTimeout(function() {
            channel.close
            }, 500);
    }

    async publishInQueue(queue: string, message: string){
        channel.assertQueue(queue, {
            durable: true,
            autoDelete: false,
            
        })
        return channel.sendToQueue(queue, Buffer.from(message));
    }
}
