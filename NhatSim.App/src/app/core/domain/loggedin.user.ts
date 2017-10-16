export class LoggedInUser {
    constructor(access_token: string, fullname: string, username: string, email: string, agentId: string
    ) {
        this.access_token = access_token;
        this.fullname = fullname;
        this.username = username;
        this.email = email;
        this.agentId = agentId;
    }
    public id: string;
    public access_token: string;
    public fullname: string;
    public username: string;
    public email: string;
    public agentId: string;
}
