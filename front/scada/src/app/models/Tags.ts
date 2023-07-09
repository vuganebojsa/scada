import { Alarm } from "./Alarm"

export interface Tag{
    id?:number,
    tagName:string,
    description:string,
    ioAddress?:string,
    currentValue:number
}
export interface DigitalInput{
    id?:number,
    description:string,
    driver:string,
    ioAddress:string,
    scanTime:string,
    onOffScan:boolean
}

export interface DigitaOutput{
    id?:number,
    description:string,
    ioAddress:string,
    initialValue:number
}
export interface OutTagsDTO{
    id?:number,
    tagName:string,
    currentValue:number,
    type?:string

}

export interface InTagsDTO{
    id?:number,
    tagName:string,
    currentValue:number,
    type?:string
    isScanOn:boolean

}

export interface AnalogInput{
    id?:number,
    description:string,
    driver:string,
    ioAddress:string,
    scanTime:string,
    alarms?:Alarm[],
    onOffScan:boolean,
    lowLimit:number,
    highLimit:number,
    units:string
}


export interface AnalogInputForDisplay{
    id?:number,
    driver?:string,
    ioAddress?:string,
    scanTime:number,
    onOffScan:boolean,
    lowLimit:number,
    highLimit:number,
    units:string,
    tagName:string,
    description:string,
    currentValue:number,
    isDeleted:boolean
}


export interface AnalogInputDto{
    id?:number,
    tagName:string,
    description:string,
    scanTime:number,
    currentValue:number,
    alarms?:Alarm[],
    lowLimit:number,
    highLimit:number,
    units:string
}

export interface AnalogOutput{
    id?:number,
    currentValue: number,
    tagName: string,
    description:string,
    initialValue:number,
    lowLimit:number,
    highLimit:number,
    units:string,
    ioAddress:string,
}

export interface TagReportTimePeriodDTO{
    value:number,
    timestamp:Date,
    tagName: string
}

export interface DigitalInputDTO{
    tagName:string,
    initialValue:number,
    description:string,
    scanTime:number
}

export interface DigitalOutputDTO{
    tagName:string,
    description:string,
    initialValue:number
}

