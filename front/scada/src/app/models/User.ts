export interface User{
    id?:number,
    username:string,
    password?:string,
    role:string
}
export interface UserDTO{
    username:string,
    role:string
}