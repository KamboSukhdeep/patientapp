import axios from "axios";
import { AddRequest, RemoveRequest, UpdateRequest, getAllRequestFail, getAllRequestSuccess, getByIdSuccess, makeRequest } from "./Action"
import { toast } from "react-toastify";

var baseURL = "https://localhost:7040/api/Patient/";


export const GetAllPatients = () => {
    return (dispatch) => {
        dispatch(makeRequest());
        setTimeout(() => {
            axios.get(baseURL + "GetAll").then(res => {
                const _list = res.data;
                dispatch(getAllRequestSuccess(_list));
            }).catch(err => {
                dispatch(getAllRequestFail(err.message));
            });
        }, 1000)

    }
}

export const CreatePatient = (data) => {
    return (dispatch) => {
        axios.post(baseURL + "Insert", data).then(res => {
            dispatch(AddRequest(data));
            toast.success('Patient created successfully.')
        }).catch(err => {
            toast.error('Failed to create patient due to :' + err.message)
        });
    }
}

export const GetPatientById = (id) => {
    return (dispatch) => {
        //dispatch(makeRequest());
        axios.get(baseURL + "Get?patientId=" + id).then(res => {
            const _obj = res.data.data;
            dispatch(getByIdSuccess(_obj));
        }).catch(err => {
            toast.error('Failed to fetch the data')
        });
    }
}

export const UpdatePatient = (data) => {
    return (dispatch) => {
        axios.put(baseURL + "Update", data).then(res => {
            dispatch(UpdateRequest(data));
            toast.success('Patient updated successfully.')
        }).catch(err => {
            toast.error('Failed to update Patient due to :' + err.message)
        });
    }
}

export const RemovePatient = (id) => {
    return (dispatch) => {
        axios.delete(baseURL + "Delete?PatientId=" + id).then(res => {
            dispatch(RemoveRequest(id));
            toast.success('Patient Removed successfully.')
        }).catch(err => {
            toast.error('Failed to remove patient due to :' + err.message)
        });
    }
}


