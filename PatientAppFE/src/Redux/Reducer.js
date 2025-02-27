import { MAKE_REQ, OPEN_POPUP, REQ_ADD_SUCC, REQ_DELETE_SUCC, REQ_GETALL_FAIL, REQ_GETALL_SUCC, REQ_GETBYID_SUCC, REQ_UPDATE_SUCC } from "./ActionType"

export const initialstate = {
    isloading: false,
    patientList: [],
    patientObj: {},
    errormessage: ''
}

export const PatientReducer = (state = initialstate, action) => {
    switch (action.type) {
        case MAKE_REQ:
            return {
                ...state,
                isloading: true
            }
        case REQ_GETALL_SUCC:
            return {
                ...state,
                isloading: false,
                patientList: action.payload.data
            }
        case REQ_GETBYID_SUCC:
            return {
                ...state,
                patientObj: action.payload
            }
        case REQ_GETALL_FAIL:
            return {
                ...state,
                isloading: false,
                patientList: [],
                errormessage: action.payload
            }
        case OPEN_POPUP:
            return {
                ...state,
                patientObj: {}
            }
        case REQ_ADD_SUCC:
            const _inputdata = { ...action.payload };
            const _maxid = Math.max(...state.patientList.map(o => o.id));
            _inputdata.id = _maxid + 1;
            return {
                ...state,
                patientList: [...state.patientList, _inputdata]
            }
        case REQ_UPDATE_SUCC:
            const _data = { ...action.payload };
            const _finaldata = state.patientList.map(item => {
                return item.id === _data.id ? _data : item
            });
            return {
                ...state,
                patientList: _finaldata
            }
        case REQ_DELETE_SUCC:
            const _filterdata = state.patientList.filter((data) => {
                return data.id !== action.payload
            })
            return {
                ...state,
                patientList: _filterdata
            }
        default: return state;
    }
}