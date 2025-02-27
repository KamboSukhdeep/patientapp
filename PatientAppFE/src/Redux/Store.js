import { combineReducers, configureStore } from "@reduxjs/toolkit";
import { PatientReducer } from "./Reducer";
import thunk from "redux-thunk";
import logger from "redux-logger";

const rootreducer = combineReducers({ patient: PatientReducer })
const compstore = configureStore({ reducer: rootreducer, middleware: [thunk, logger] })
export default compstore;