cmake_minimum_required(VERSION 3.1.0)
project(SimpleExample)

# Set the path to the Boost root directory
# set(BOOST_ROOT "${CMAKE_CURRENT_SOURCE_DIR}/boost_1_84_0")
set(BOOST_ROOT C:/local/boost_1_84_0)

# Find Boost
set(Boost_USE_STATIC_LIBS ON) 
find_package(Boost 1.84.0 REQUIRED COMPONENTS system)

# Include Boost
include_directories(${Boost_INCLUDE_DIR})

# Add your source file
add_executable(SimpleExample simple_example.cpp)

# Link Boost
target_link_libraries(SimpleExample ${Boost_LIBRARIES})
