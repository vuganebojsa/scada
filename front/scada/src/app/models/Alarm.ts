export interface Alarm{
    id?:number,
    type:string,
    borderValue?:number,
    timeOfActivation:Date,
    measureUnit:string,
    priority?:number
}