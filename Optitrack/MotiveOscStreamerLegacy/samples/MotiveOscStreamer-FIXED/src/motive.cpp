/*
* motive.cpp
*
* Copyright (c) 2015 Zhao He, Wieden+Kennedy
* Copyright (c) 2014 Bjorn Blissing
*
*/

#include "motive.h"
#include <iostream>

int Motive::init()
{
	if (m_projectFile.empty()) {
		std::cerr << "Error: OptiTrack Project filename cannot be empty." << std::endl;
		return 1;
	}

	int errorCode = 0;
	// Try to initialize the OptiTrack system
	errorCode = checkResult(TT_Initialize());
	
	// Do an update to pick up any recently-arrived cameras.
	errorCode = checkResult(TT_Update());
	
	// Load project definition file
	errorCode = checkResult(TT_LoadProject(m_projectFile.c_str()));
	
	if (errorCode == NPRESULT_SUCCESS) {
		m_initialized = true;
		return 0;
	}

	return errorCode;
}

int Motive::terminate() {
	int errorCode = checkResult(TT_Shutdown());

	errorCode = checkResult(TT_Shutdown());

	m_initialized = false;

	return 0;
}

bool Motive::loadRigidBodies(std::string filename) {
	if (TT_LoadTrackables(filename.c_str()) == NPRESULT_SUCCESS) {
		return true;
	}
	return false;
}

bool Motive::removeRigidBody(int index) {
	if(TT_RemoveTrackable(index) == NPRESULT_SUCCESS) {
		return true;
	}
	return false;
}

double Motive::getTimeStamp() const {
	if (m_initialized) {
		return TT_FrameTimeStamp();
	}
	return 0;
}

int Motive::getNumberofMarkers() const {
	if (m_initialized) {
		return TT_FrameMarkerCount();
	}
	return 0;
}

int Motive::getNumberOfCameras() const {
	if (m_initialized) {
		return TT_CameraCount();
	}
	return 0;
}

int Motive::getNumberOfRigidBodies() const {
	if (m_initialized) {
		return TT_TrackableCount();
	}
	return 0;
}

std::string Motive::getNameOfCamera(int id) const {
	if (m_initialized) {
		if (id <= TT_CameraCount()) {
			return std::string(TT_CameraName(id));
		}
	}
	return std::string("");
}

std::string Motive::getNameOfRigidBody(int id) const {
	if (m_initialized) {
		if (id <= TT_TrackableCount()) {
			return std::string(TT_TrackableName(id));
		}
	}
	return std::string("");
}

bool Motive::isRigidBodyTracked(int index) const
{
	return TT_IsTrackableTracked(index);
}

int Motive::getRigidBodyID(int index) const
{
	return TT_TrackableID(index);
}

bool Motive::update()
{
	if (TT_Update() == NPRESULT_SUCCESS)
		return true;
	return false;
}

bool Motive::updateSingleFrame()
{
	if (TT_UpdateSingleFrame() == NPRESULT_SUCCESS)
		return true;
	return false;
}

void Motive::getPositionAndOrientation(int index, float& x, float& y, float& z, float& qx, float& qy, float& qz, float& qw, float& yaw, float& pitch, float& roll) const
{
	if (m_initialized) {
		TT_TrackableLocation(index, &x, &y, &z, &qx, &qy, &qz, &qw, &yaw, &pitch, &roll);
	}
}

int Motive::checkResult(int result) 
{
	if (result != NPRESULT_SUCCESS) {
		std::cerr << "Error: " << TT_GetResultString(result) << std::endl;
	}
	return result;
}
